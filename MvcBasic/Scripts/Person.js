var MvcSamples;
(function (MvcSamples) {
    var Person = (function () {
        function Person(name, birth) {
            this.name = name;
            this.birth = birth;
        }
        Person.prototype.toString = function () {
            return this.name + " " + this.birth.toLocaleDateString();
        };
        return Person;
    }());
    MvcSamples.Person = Person;
})(MvcSamples || (MvcSamples = {}));
var p = new MvcSamples.Person("yamada-rio", new Date(2010, 1, 1));
window.alert(p.toString());
//# sourceMappingURL=Person.js.map