using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace MvcBasic.Extentions
{
    public class BlackwordAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _options;

        /// <summary>
        /// NGワード検証用の属性クラス
        /// </summary>
        /// <param name="options"></param>
        public BlackwordAttribute(string options)
        {
            // 入力されたカンマ区切りのNGワード
            _options = options;
            // エラーメッセージ
            this.ErrorMessage = @"{0}には{1}を含むことはできません";
        }

        public override string FormatErrorMessage(string name)
        {
            // ErrorMessageString=ErrorMessage（リソース利用の場合を考えて直接ErrorMessageを参照しない）, name=表示名, _options=候補リスト
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _options);
        }

        /// <summary>
        /// 入力値にNGワードが含まれているか検証する
        /// </summary>
        /// <param name="value">入力値</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            // 入力がある場合のみ検証
            if (value == null) return true;

            string[] list = _options.Split(',');
            foreach (var word in list)
            {
                if (((string)value).Contains(word))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // 検証ルールを準備
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "blackword",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters["options"] = _options;
            yield return rule; // ルールをクライアントに渡してあげるイメージ
        }
    }
}