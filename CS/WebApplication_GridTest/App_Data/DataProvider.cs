using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication_GridTest {
    public class DataProvider {
        static IList<DataItem> result;
        static List<DictionaryItem> result2;
        static List<DictionaryItem> result3;
        static DataProvider() {
            result = new List<DataItem>();
            result.Add(new DataItem(1, DataType.Text, "Example Text"));
            result.Add(new DataItem(2, DataType.DateTime, DateTime.Now.ToShortDateString()));
            result.Add(new DataItem(3, DataType.Dictionary1, "1"));
            result.Add(new DataItem(4, DataType.Dictionary2, "11"));

            result2 = new List<DictionaryItem>();
            result2.Add(new DictionaryItem(1, "Combo Data 1"));
            result2.Add(new DictionaryItem(2, "Combo Data 2"));
            result2.Add(new DictionaryItem(3, "Combo Data 3"));

            result3 = new List<DictionaryItem>();
            result3.Add(new DictionaryItem(11, "Combo Data 11"));
            result3.Add(new DictionaryItem(22, "Combo Data 22"));
            result3.Add(new DictionaryItem(33, "Combo Data 33"));
        }

        public static IList<DataItem> GetAll() {
            return result;
        }

        public static IList<DictionaryItem> GetDictionaryData(DataType dataType) {
            return (dataType == DataType.Dictionary1) ? result2 : result3;
        }

        public static DictionaryItem GetDictionaryItem(DataType dataType, int itemId) {
            var target = (dataType == DataType.Dictionary1) ? result2 : result3;
            return (from q in target
                    where q.Id == itemId
                    select q).FirstOrDefault();
        }

        public static bool Update(int Id, DataType type, string datavalue) {
            DataItem item = result.Where(i => i.Id == Id).FirstOrDefault();
            item.Type = type;
            item.DataValue = datavalue;
            return true;
        }
    }

    public class DataItem {
        public int Id { get; set; }
        public DataType Type { get; set; }
        public string DataValue { get; set; }

        public DataItem(int id, DataType type, string dataValue) {
            Id = id;
            Type = type;
            DataValue = dataValue;
        }
    }

    public enum DataType : int {
        Text,
        DateTime,
        Dictionary1,
        Dictionary2
    }

    public class DictionaryItem {
        public int Id { get; set; }
        public string Data { get; set; }
        public DictionaryItem(int id, string data) {
            Id = id;
            Data = data;
        }
    }
}