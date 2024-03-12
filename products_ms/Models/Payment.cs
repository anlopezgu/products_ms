using Google.Cloud.Firestore;

namespace products_ms.Models;

[FirestoreData]
public class Payment : FirebaseDocument
{
    [FirestoreProperty]
    public string productID { get; set; }
    [FirestoreProperty]
    public string? userID { get; set; }
    [FirestoreProperty]
    public int? amount { get; set; }
    [FirestoreProperty]
    public DateTime? dateTime { get; set; }
}