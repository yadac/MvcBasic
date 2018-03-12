module MvcSamples {
    export class Person {
        constructor(private name: string, private birth: Date) {

        }

        public toString(): string {
            return this.name + " " + this.birth.toLocaleDateString();
        }
    }
}

var p = new MvcSamples.Person("yamada-rio", new Date(2010, 1, 1));
window.alert(p.toString());