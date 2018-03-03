var person=function(name){
    return{
        greet:function(){
            console.log("hello"+name);
        },
        changeName:function(newName){
name=newName;
console.log("your name is changed to"+newName);
        }

    }
}
var toni =person("toni");
console.log(toni.name);
toni.greet();
name="chefo";
toni.greet();
toni.changeName("pesho");
newName="gosho";
toni.changeName("chefo");

