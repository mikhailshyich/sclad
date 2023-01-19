using Sclad.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sclad.Model
{
    public static class DataWorker
    {
        //получить все товары
        public static List<Goods> GetGoods()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Goods.ToList();
                return result;
            }
        }

        //добавить новый товар
        public static string CreateGoods(string Title)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем добавлен ли товар
                bool checkIsExist = db.Goods.Any(el => el.Title == Title);
                if (!checkIsExist)
                {
                    Goods newGoods = new Goods { Title = Title};
                    db.Goods.Add(newGoods);
                    db.SaveChanges();
                    result = "Успешно!";
                }
                return result;
            }
        }
        //редактировать товар
        public static string EditGoods(Goods oldGoods, string newTitle)
        {
            string result = "Такого товара не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                    Goods goods = db.Goods.FirstOrDefault(g => g.Id == oldGoods.Id);
                    goods.Title = newTitle;
                    db.SaveChanges();
                    result = "Успешно";
            }
            return result;
        }
    }
}
