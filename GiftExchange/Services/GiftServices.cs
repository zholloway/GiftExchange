﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiftExchange.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GiftExchange.Services
{
    public class GiftServices
    {
        const string PathToGiftDatabase = @"Server=localhost\SQLEXPRESS;Database=Exchange;Trusted_Connection=True;";

        public static List<Gift> GetAllGifts()
        {
            var allGifts = new List<Gift>();

            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var query = "SELECT * FROM Gifts";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allGifts.Add(new Gift(reader));
                }
                connection.Close();
            }
            

            return allGifts;
        }

        public static void DeleteGift(int giftID)
        {
            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var cmd = new SqlCommand("DELETE FROM Gifts WHERE ID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", giftID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Gift GetOneGift(int giftID)
        {
            var gift = new Gift();

            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var query = "SELECT * FROM Gifts WHERE ID=@ID";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", giftID);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gift = new Gift(reader);
                }
                connection.Close();
            }

            return gift;
        }

        public static Gift OpenGift(int giftID)
        {
            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var cmd = new SqlCommand($"UPDATE Gifts SET [IsOpened] = 'True' " +
                    $"WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", giftID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            return GetOneGift(giftID);
        }

        public static void EditGift(int id, FormCollection collection)
        {
            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var query = "UPDATE Gifts " +
                            "SET [Contents] = @Contents," +
                            "[GiftHint] = @GiftHint," +
                            "[ColorWrappingPaper] = @ColorWrappingPaper," +
                            "[Height] = @Height," +
                            "[Depth] = @Depth," +
                            "[Weight] = @Weight," +
                            "[IsOpened] = @IsOpened " +
                            "WHERE ID = @ID";

                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Contents", collection["Contents"]);
                cmd.Parameters.AddWithValue("@GiftHint", collection["GiftHint"]);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", collection["ColorWrappingPaper"]);
                cmd.Parameters.AddWithValue("@Height", collection["Height"]);
                cmd.Parameters.AddWithValue("@Depth", collection["Depth"]);
                cmd.Parameters.AddWithValue("@Weight", collection["Weight"]);
                cmd.Parameters.AddWithValue("@IsOpened", collection["IsOpened"]);
                cmd.Parameters.AddWithValue("@ID", collection["ID"]);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void CreateGift(FormCollection collection)
        {
            using (var connection = new SqlConnection(PathToGiftDatabase))
            {
                var query = "INSERT INTO Gifts (Contents, GiftHint, ColorWrappingPaper, Height, Depth, Weight, IsOpened) "
                            + "Values (@Contents, @GiftHint, @ColorWrappingPaper, @Height, @Depth, @Weight, @IsOpened)";

                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Contents", collection["Contents"]);
                cmd.Parameters.AddWithValue("@GiftHint", collection["GiftHint"]);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", collection["ColorWrappingPaper"]);
                cmd.Parameters.AddWithValue("@Height", collection["Height"]);
                cmd.Parameters.AddWithValue("@Depth", collection["Depth"]);
                cmd.Parameters.AddWithValue("@Weight", collection["Weight"]);
                cmd.Parameters.AddWithValue("@IsOpened", collection["IsOpened"]);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }   
        }
    }
}