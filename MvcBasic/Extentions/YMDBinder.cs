using System;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class YMDBinder : IModelBinder
    {

        /// <summary>
        /// 入力値をモデルにバインドする
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext">入力値</param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = default(DateTime);

            try
            {
                result = new DateTime(
                    GetYmd(bindingContext, "year"),
                    GetYmd(bindingContext, "month"),
                    GetYmd(bindingContext, "day")
                    );
            }
            catch (Exception e)
            {
            }

            // これがそのままモデルにバインドされる
            return result;
        }

        private int GetYmd(ModelBindingContext context, string type)
        {
            var result = 0;
            // 入力値から値を取得する
            // date.yearの場合、date = modelname, year = type
            var value = context.ValueProvider.GetValue($"{context.ModelName}.{type}");
            try
            {
                result = (int)value.ConvertTo(typeof(int));
            }
            catch (Exception e)
            {
            }

            return result;
        }
    }
}