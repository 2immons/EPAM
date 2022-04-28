// //Создать вспомогательную библиотеку для хранения данных в памяти приложения.

class StorageClass {
    constructor(){
        this.arrayOfObjects = [];
        this.lenght = 0;
    }

    Add(obj) //принимает объект и позволяет добавить его в коллекцию
    {
        this.arrayOfObjects[this.lenght] = obj;    
        this.lenght++; 
    }

    Get(id) //принимает id и возвращает найденный объект или NULL если не найден
    {
        if (this.arrayOfObjects[id] != null)
            return this.arrayOfObjects[id]
        else
            return null
    }
    
    GetAll() //возвращает весь массив объектов
    {
        return this.arrayOfObjects
    }

    Remove(id) //принимает id и возвращает удаленный объект
    {
        let element = this.arrayOfObjects[id]
        delete this.arrayOfObjects[id]
        return element
    }

    Update(id , obj) // принимает id первым параметром и объект-вторым. Обновляет поля объекта новыми значениями
    {
        for (let i = 0; i < Object.keys(obj).length; i++) {
            let currentKey = Object.keys(obj)[i];
            this.arrayOfObjects[id][currentKey] = obj[currentKey];
        }
    }

    Replace(id , obj) // принимает id и заменяет старый объект - новым
    {
        this.arrayOfObjects[id] = obj
    }   
}

let ex1 = { name : "John" }

let ex2 = { name : "Boris" }

let ex3 = { name : "Victor" }


let ex4 = { name : "Anton" }

let storage = new StorageClass();

storage.Add(ex1);
storage.Add(ex2);
storage.Add(ex3);

console.log("\nInput data:")
console.log(storage.GetAll())

console.log("\nGet 0 id:")
console.log(storage.Get(0));

console.log("\nUpdate 2 id with ex4 and replace 1 id with ex1\nRemove 0 id and return it (to console):")
console.log(storage.Remove(0));
storage.Update(2, ex4)
storage.Replace(1, ex1)

console.log("\nFinal data:")
console.log(storage.GetAll())