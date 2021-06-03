using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using StratixRuanDataLayer.Linq2SQL;
using System.Reflection;
using System;
using StratixRuanInterfaces;

namespace StratixRuanBusinessLogic
{
    public class BusinessLogicList<BusinessLogicType, DataLayerType> : BindingList<BusinessLogicType>
        where BusinessLogicType : BusinessLogicBase<BusinessLogicType, DataLayerType>, new()
        where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
    {
      

        public virtual void Save(bool saveChildren = true)
        {
            if (saveChildren)
            {
                foreach (BusinessLogicType child in this)
                {
                    child.Save(true);
                }
            }
            
            else if (this is IListSaveable)
            {
                ListSave(this.ToList());
            }
            else
            {
                foreach (BusinessLogicType child in this)
                {
                    child.Save(false);
                }
            }
        }

        private void ListSave(List<BusinessLogicType> objectList)
        {
            DataItemList<DataLayerType> DataItems = new DataItemList<DataLayerType>();

            for (int i = 0; i < objectList.Count; i++)
            {
                BusinessLogicType child = objectList[i];
                DataItem<DataLayerType> dataItem = new DataItem<DataLayerType>(child.GetFetchedObject(), child.ToDataType());
                DataItems.Add(dataItem);
            }

            if (DataItems.Count > 0)
            {
                DataItems = DataItems.Save();

                for (int i = 0; i < objectList.Count; i++)
                {
                    BusinessLogicType child = objectList[i];
                    child.PopulateBusinessObject(DataItems[i].Result);
                    child.ClearLazyLoadedLists();
                }
            }
        }

        public void AddRange(BusinessLogicList<BusinessLogicType, DataLayerType> items)
        {
            foreach (BusinessLogicType blt in items)
            {
                this.Add(blt);
            }
        }

        public bool Contains(long number)
        {
            BusinessLogicType result = (from s in this where s.Number == number select s).SingleOrDefault();
            return result != null;
        }

        public bool Contains(string code)
        {
            BusinessLogicType result = (from s in this where s.Code.ToLowerInvariant() == code.ToLowerInvariant() select s).SingleOrDefault();
            return result != null;
        }

        public void Remove(long number)
        {
            BusinessLogicType result = (from s in this where s.Number == number select s).SingleOrDefault();

            if(result != null)
                this.Remove(result);
        }

        public void Add(long number)
        {
            BusinessLogicType result = (from s in this where s.Number == number select s).SingleOrDefault();

            if (result != null)
                this.Add(result);
        }

        public int IndexOf(long number)
        {
            int index = -1;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Number == number)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Indexer that allows referencing by object Code. Returns the first item in a list with a matching Code or null if not matching
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public BusinessLogicType this[string code]
        {
            get
            {
                return this.Where(i => i.Code == code).FirstOrDefault();
            }
        }

      

       

        public BusinessLogicType ByNumber(long? number)
        {
            if (number.HasValue)
            {
                foreach (BusinessLogicType blt in this)
                {
                    if (blt.Number == number)
                    {
                        return blt;
                    }
                }
            }

            return null;
        }

        public BusinessLogicType ByCode(string code)
        {
            foreach (BusinessLogicType blt in this)
            {
                if (blt.Code == code)
                {
                    return blt;
                }
            }
            return null;
        }

        public BusinessLogicList<BusinessLogicType, DataLayerType> ByCodeAndDescription(string code, bool includeDeleted = false)
        {
            if (code == null)
            {
                code = "";
            }

            BusinessLogicList<BusinessLogicType, DataLayerType> bll = new BusinessLogicList<BusinessLogicType, DataLayerType>();

            foreach (BusinessLogicType blt in this)
            {
                if (!includeDeleted && blt.IsDeleted)
                {
                    continue;
                }

                if ((blt.Code != null && blt.Code.ToLowerInvariant().Contains(code.ToLowerInvariant())) || (blt.Description != null && blt.Description.ToLowerInvariant().Contains(code.ToLowerInvariant())))
                {
                    bll.Add(blt);
                }
            }

            return bll;
        }

        public BusinessLogicList<BusinessLogicType, DataLayerType> LikeCode(string code, int numberOfRecords)
        {
            if (code == null)
            {
                code = "";
            }

            BusinessLogicList<BusinessLogicType, DataLayerType> bll = new BusinessLogicList<BusinessLogicType, DataLayerType>();

            int count = 0;
            foreach (BusinessLogicType blt in this)
            {
                if (numberOfRecords < count)
                {
                    break;
                }

                if (blt.Code != null && blt.Code.ToLowerInvariant().Contains(code.ToLowerInvariant()))
                {
                    bll.Add(blt);
                    count++;
                }
            }
            return bll;
        }

        public BusinessLogicType Default()
        {
            foreach (BusinessLogicType blt in this)
            {
                string propertyName = "Default";
                Type t = typeof(BusinessLogicType);
                PropertyInfo propertyInfo = t.GetProperty(propertyName);
                bool isDefault = false;
                if (propertyInfo != null)
                {
                    var v = propertyInfo.GetValue(blt, null);
                    isDefault = Convert.ToBoolean(v);
                }

                if (isDefault)
                {
                    return blt;
                }
            }

            return null;
        }

        public BusinessLogicList<BusinessLogicType, DataLayerType> To(Type t)
        {
            var typeInstance = Activator.CreateInstance(t);
            BusinessLogicList<BusinessLogicType, DataLayerType> returnValue = null;

            if(typeInstance is BusinessLogicList<BusinessLogicType, DataLayerType>)
            {
                returnValue = typeInstance as BusinessLogicList<BusinessLogicType, DataLayerType>;
                foreach (var v in this)
                {
                    returnValue.Add(v);
                }
            }

            return returnValue;
        }
    }
}
