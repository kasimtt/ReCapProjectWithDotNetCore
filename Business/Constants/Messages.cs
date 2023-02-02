﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedCarMessage = "Araç eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz.";
        public static string MaintananceTime = "Sistem şuan bakımda";
        public static string ListedCarMessage = "Arabalar Listelendi";
        public static string ElementNotFount = "İlgili eleman bulunamadı";
        public static string ElementFound = "Listelenme gerçekleşti";
        public static string AddedCustomerMessage = "Müşteri eklendi";
        public static string DeletedCustomerMessage = "müşteri silindi";
        public static string ListedCustomerMessage = "müşteri listelendi";
        public static string UpgatedCustomerMessage = "müşteri güncellendi";
        public static string AddedRentalMessage = "Araç kiralandı";
        public static string DeletedRentalMessage = "Araç kiradan kaldırıldı";
        public static string AddedUserMessage = "kullanıcı eklendi";
        public static string DeletedUserMessage= "kullanıcı silindi";

        public static string AddColorMessage = "renk eklendi";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserRegistered = "kayıt tamamlanmıştır";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "şifre hatalı";
        public static string SuccessfulLogin = "giriş başarılı";
        public static string UserAlreadyExist = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreate = "token oluşturuldu";
    }
}
