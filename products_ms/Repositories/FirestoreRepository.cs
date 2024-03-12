using Google.Cloud.Firestore;
using Newtonsoft.Json;
using products_ms.Models;

namespace products_ms.Repositories;

public class FirestoreRepository 
{
    private readonly string CollectionName;
    public FirestoreDb firestoreDb;

    public FirestoreRepository(string CollectionName)
    {
        string filepath = "token/productsdb-e9adf-firebase-adminsdk-4q0ou-4357d5246d.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
        firestoreDb = FirestoreDb.Create("productsdb-e9adf"); // cambiar 42
        this.CollectionName = CollectionName;
    }

    public T Add<T>(T model) where T : FirebaseDocument
    {
        try
        {
            CollectionReference collectionReference = firestoreDb.Collection(CollectionName);
            DocumentReference newDocument = collectionReference.AddAsync(model).GetAwaiter().GetResult();
            model.Id = newDocument.Id;
            return model;
        }
        catch
        {
            return null;
        }
    }

    public T Get<T>(T record) where T : FirebaseDocument
    {
        DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(record.Id);
        DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
        if (snapshot.Exists) 
        {
            T usr = snapshot.ConvertTo<T>();
            usr.Id = snapshot.Id;
            return usr;
        }
        else
        {
            return null;
        }
    }

    public bool Delete<T>(T model) where T : FirebaseDocument
    {
        try
        {
            DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
            getDocument.DeleteAsync().GetAwaiter().GetResult();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update<T>(T model) where T : FirebaseDocument
    {
        try
        {
            DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
            getDocument.SetAsync(model, SetOptions.MergeAll).GetAwaiter().GetResult();
            return true;
        }
        catch
        {
            return false;
        }
    }

    
}