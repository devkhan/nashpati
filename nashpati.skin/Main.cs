using AppKit;
using Raven.Client;
using Raven.Client.Embedded;

namespace nashpati.skin
{
//public class Dog : RealmObject
//{
//	public string Name { get; set; }
//	public int Age { get; set; }
//	public string Owner { get; set; }
//}
public class Territory
{
	public string Code { get; set; }

	public string Name { get; set; }
}

	static class MainClass
	{
		
		static void Main(string[] args)
		{
			NSApplication.Init();
			NSApplication.Main(args);
			//EmbeddableDocumentStore store = new EmbeddableDocumentStore
			//{
			//	DataDirectory = "Data"
			//};
			//using (var d_store = store.Initialize())
			//{
			//	using (IDocumentSession session = d_store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
			//	{
			//		var t = new Territory();
			//		t.Code = "GPKB";
			//		t.Name = "Bhadve";
			//		session.Store(t);
			//		session.SaveChanges();
			//	}
			//}
			//var realm = Realm.GetInstance();
			//using(var transaction = realm.BeginWrite()) 
			//{
			//	var dog = new Dog();
			//	dog.Name = "John";
			//	dog.Age = 56;
			//    transaction.Commit();
			//}
		}
	}
}
