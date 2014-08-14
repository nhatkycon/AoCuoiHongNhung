using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using linh.common;
using Version = Lucene.Net.Util.Version;
namespace docsoft.entities
{
    public class Obj 
    {
        #region Properties
        public Guid Id { get; set; }
        public Guid RowId { get; set; }
        public String Username { get; set; }
        public String Ten { get; set; }
        public String Kieu { get; set; }
        public String Url { get; set; }
        public DateTime NgayTao { get; set; }
        public string Alias { get; set; }
        public string NoiDung { get; set; }
        public Guid ID
        {
            get { return Id; }
        }
        #endregion
        #region Contructor
        public Obj()
        { }
        #endregion
        #region Customs properties

        #endregion
    }
    public class SearchManager
    {
        public static string Dic
        {
            get
            {
                return HostingEnvironment.MapPath("~/index/");
            }
        }
        public static void Add(string ten, string noiDung, string alias, string rowId, string url, string loai)
        {
            Add(ten, noiDung, noiDung, alias, rowId, url, loai);

        }
        public static void Add(string ten, string noiDung, string searchContent, string alias, string rowId, string url, string loai)
        {
            noiDung = Lib.NoHtml(noiDung);
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            var doc = new Document();
            doc.Add(new Field("Ten", ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", searchContent, Field.Store.YES,
                              Field.Index.NOT_ANALYZED));
            doc.Add(new Field("SearchContent", noiDung, Field.Store.YES,
                                  Field.Index.ANALYZED));
            doc.Add(new Field("RowId", rowId, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("ID", rowId, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Url", url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Loai", loai, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
            writer.Optimize();
            writer.Commit();
            writer.Close();

        }
        public static void ReIndex()
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            foreach (var item in KhachHangDal.SelectAll())
            {
                var doc = new Document();
                doc.Add(new Field("Ten", item.Ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field("NoiDung", string.Format("Khách hàng: {0}, Mobile: {1}, Địa chỉ: {2}"
                        , item.Ten, item.Mobile, item.DiaChi), Field.Store.YES,
                                  Field.Index.NOT_ANALYZED));
                doc.Add(new Field("SearchContent", item.IndexContent, Field.Store.YES,
                                  Field.Index.ANALYZED));
                doc.Add(new Field("RowId", item.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field("ID", item.ID.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("Url", item.Url, Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field("Loai", typeof(KhachHang).Name, Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(doc);
            }
            writer.Optimize();
            writer.Commit();
            writer.Close();

        }
        //public static List<Obj> SearchXe(string q, int from, int size, out int total)
        //{
        //    var directory = FSDirectory.Open(new DirectoryInfo(Dic));
        //    var analyzer = new StandardAnalyzer(Version.LUCENE_29);
        //    var indexReader = IndexReader.Open(directory, true);
        //    var indexSearch = new IndexSearcher(indexReader);

        //    var mainQuery = new BooleanQuery();

        //    if(!string.IsNullOrEmpty(q))
        //    {
        //        var queryParser = new QueryParser(Version.LUCENE_29, "SearchContent", analyzer);
        //        var query = queryParser.Parse(q);
        //        mainQuery.Add(query, BooleanClause.Occur.MUST);
        //    }
        //    var queryParserLoai = new QueryParser(Version.LUCENE_29, "Loai", analyzer);
        //    var queryLoai = queryParserLoai.Parse("Xe");
        //    mainQuery.Add(queryLoai, BooleanClause.Occur.MUST);

        //    var resultDocs = indexSearch.Search(mainQuery, indexReader.MaxDoc());
        //    var hits = resultDocs.scoreDocs;
        //    total = hits.Length;
        //    var list = hits.Select(hit => indexSearch.Doc(hit.doc)).Select(documentFromSearcher => new Obj()
        //    {
        //        Kieu =
        //            documentFromSearcher
        //            .Get(
        //                "Loai")
        //        ,
        //        RowId =
        //            new Guid(
        //            documentFromSearcher
        //                .Get(
        //                    "RowId"))
        //        ,
        //        Url =
        //            documentFromSearcher
        //            .Get(
        //                "Url")
        //        ,
        //        NoiDung =
        //            documentFromSearcher
        //            .Get(
        //                "NoiDung")
        //        ,
        //        Ten =
        //            documentFromSearcher
        //            .Get(
        //                "Ten")
        //    }).Skip(
        //                                                                                                   from).Take(
        //                                                                                                       size).ToList();
        //    indexSearch.Close();
        //    directory.Close();
        //    return list;
        //}
        //public static List<Obj> Search(string q, int from,int size, out int total)
        //{
        //    var directory = FSDirectory.Open(new DirectoryInfo(Dic));
        //    var analyzer = new StandardAnalyzer(Version.LUCENE_29);
        //    var indexReader = IndexReader.Open(directory, true);
        //    var indexSearch = new IndexSearcher(indexReader);
        //    var queryParser = new QueryParser(Version.LUCENE_29, "SearchContent", analyzer);
        //    var query = queryParser.Parse(q);
        //    var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
        //    var hits = resultDocs.scoreDocs;
        //    total = hits.Length;
        //    var list = hits.Select(hit => indexSearch.Doc(hit.doc)).Select(documentFromSearcher => new Obj()
        //                                                                                               {
        //                                                                                                   Kieu =
        //                                                                                                       documentFromSearcher
        //                                                                                                       .Get(
        //                                                                                                           "Loai")
        //                                                                                                   ,
        //                                                                                                   RowId =
        //                                                                                                       new Guid(
        //                                                                                                       documentFromSearcher
        //                                                                                                           .Get(
        //                                                                                                               "RowId"))
        //                                                                                                   ,
        //                                                                                                   Url =
        //                                                                                                       documentFromSearcher
        //                                                                                                       .Get(
        //                                                                                                           "Url")
        //                                                                                                   ,
        //                                                                                                   NoiDung =
        //                                                                                                       documentFromSearcher
        //                                                                                                       .Get(
        //                                                                                                           "NoiDung")
        //                                                                                                   ,
        //                                                                                                   Ten =
        //                                                                                                       documentFromSearcher
        //                                                                                                       .Get(
        //                                                                                                           "Ten")
        //                                                                                               }).Skip(
        //                                                                                                   from).Take(
        //                                                                                                       size).ToList();
        //    indexSearch.Close();
        //    directory.Close();
        //    return list;
        //}
        public static void Remove(Guid rowid)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var indexReader = IndexReader.Open(directory, false);
            indexReader.DeleteDocuments(new Term("RowId", rowid.ToString()));
            indexReader.Close();
        }
        public static List<Obj> SearchByLoai(string q, string loai, int from, int size, out int total)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var indexReader = IndexReader.Open(directory, true);
            var indexSearch = new IndexSearcher(indexReader);

            var mainQuery = new BooleanQuery();

            if (!string.IsNullOrEmpty(q))
            {
                var queryParser = new QueryParser(Version.LUCENE_29, "SearchContent", analyzer);
                var query = queryParser.Parse(q);
                mainQuery.Add(query, BooleanClause.Occur.MUST);
            }
            var queryParserLoai = new QueryParser(Version.LUCENE_29, "Loai", analyzer);
            var queryLoai = queryParserLoai.Parse(loai);
            mainQuery.Add(queryLoai, BooleanClause.Occur.MUST);

            var resultDocs = indexSearch.Search(mainQuery, indexReader.MaxDoc());
            var hits = resultDocs.scoreDocs;
            total = hits.Length;
            var list = hits.Select(hit => indexSearch.Doc(hit.doc)).Select(documentFromSearcher => new Obj()
            {
                Kieu =
                    documentFromSearcher
                    .Get(
                        "Loai")
                ,
                RowId =
                    new Guid(
                    documentFromSearcher
                        .Get(
                            "RowId"))
                ,
                Id = 
                    new Guid(
                    documentFromSearcher
                        .Get(
                            "ID"))
                ,
                Url =
                    documentFromSearcher
                    .Get(
                        "Url")
                ,
                NoiDung =
                    documentFromSearcher
                    .Get(
                        "NoiDung")
                ,
                Ten =
                    documentFromSearcher
                    .Get(
                        "Ten")
            }).Skip(
                                                                                                           from).Take(
                                                                                                               size).ToList();
            indexSearch.Close();
            directory.Close();
            return list;
        }
        public static List<Obj> Search(string q, int from, int size, out int total)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var indexReader = IndexReader.Open(directory, true);
            var indexSearch = new IndexSearcher(indexReader);
            var queryParser = new QueryParser(Version.LUCENE_29, "SearchContent", analyzer);
            var query = queryParser.Parse(q);
            var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
            var hits = resultDocs.scoreDocs;
            total = hits.Length;
            var list = hits.Select(hit => indexSearch.Doc(hit.doc)).Select(documentFromSearcher => new Obj()
                                                                                                       {
                                                                                                           Kieu =
                                                                                                               documentFromSearcher
                                                                                                               .Get(
                                                                                                                   "Loai")
                                                                                                           ,
                                                                                                           RowId =
                                                                                                               new Guid(
                                                                                                               documentFromSearcher
                                                                                                                   .Get(
                                                                                                                       "RowId"))
                                                                                                           ,
                                                                                                           Url =
                                                                                                               documentFromSearcher
                                                                                                               .Get(
                                                                                                                   "Url")
                                                                                                           ,
                                                                                                           NoiDung =
                                                                                                               documentFromSearcher
                                                                                                               .Get(
                                                                                                                   "NoiDung")
                                                                                                           ,
                                                                                                           Ten =
                                                                                                               documentFromSearcher
                                                                                                               .Get(
                                                                                                                   "Ten")
                                                                                                       }).Skip(
                                                                                                           from).Take(
                                                                                                               size).ToList();
            indexSearch.Close();
            directory.Close();
            return list;
        }
        public static void Remove(string rowid)
        {
            Remove(new Guid(rowid));
        }
    }
}
