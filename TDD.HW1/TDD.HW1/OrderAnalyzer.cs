using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.HW1
{
    public class OrderAnalyzer<T>
    {
        private IEnumerable<T> DataList;

        public OrderAnalyzer(IEnumerable<T> dataList)
        {
            this.DataList = dataList;
        }

        public List<int> GetSumByCost(decimal groupSize, string fieldName)
        {
            var result = new List<int>();

            var data = DataList.ToList();

            var groupsNum = Math.Ceiling(data.Count / groupSize);

            for (int i = 0; i < groupsNum; i++)
            {
                //data..Take(groupSize).
                var sum = 0;
                var subData = data.Skip(i * (int)groupSize).Take((int)groupSize).ToList();

                subData.ForEach(f =>
                {
                    var props = f.GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        if (string.Equals(prop.Name, fieldName))
                            sum += (int)(prop.GetValue(f));
                    }
                });
                result.Add(sum);
            }

            return result;
        }

    }
}
