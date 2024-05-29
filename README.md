# Change Management Console Application

## Overview

This project is a console application for managing changes and their items. Each change can have multiple items, and both changes and items have states that progress through a defined workflow.

## Features

- Add new states dynamically.
- Add, update, and delete change items.
- Automatically progress change states based on the states of their items.
- User-friendly command interface for managing changes and items.

## States

### Default States

- `dev` (Development)
- `testReady` (Test Ready)
- `test` (Test)
- `preprodReady` (Pre-production Ready)
- `preprod` (Pre-production)

### Adding New States

New states can be added dynamically through the console interface.

## How to Run

1. Clone the repository.
2. Open the project in your preferred C# IDE.
3. Build and run the application.

## Commands

- `durumekle` - Add a new state.
- `durumsil` - Delete an existing state.
- `sonrakidurum` - Move the change to the next state.
- `itemekle` - Add a new item to the change.
- `itemsil` - Delete an item from the change.
- `sonrakiitemdurum` - Move an item to the next state.
- `exit` - Exit the application.

---

# Değişiklik Yönetim Konsol Uygulaması

## Genel Bakış

Bu proje, değişiklikleri ve bunların öğelerini yönetmek için bir konsol uygulamasıdır. Her değişiklik birden fazla öğeye sahip olabilir ve hem değişiklikler hem de öğeler, tanımlanmış bir iş akışında ilerleyen durumlara sahiptir.

## Özellikler

- Dinamik olarak yeni durumlar ekleme.
- Değişiklik öğeleri ekleme, güncelleme ve silme.
- Öğelerin durumlarına göre değişiklik durumlarını otomatik olarak ilerletme.
- Değişiklikleri ve öğeleri yönetmek için kullanıcı dostu komut arayüzü.

## Durumlar

### Varsayılan Durumlar

- `dev` (Geliştirme)
- `testReady` (Test İçin Hazır)
- `test` (Test)
- `preprodReady` (Ön Üretim İçin Hazır)
- `preprod` (Ön Üretim)

### Yeni Durum Ekleme

Yeni durumlar konsol arayüzü üzerinden dinamik olarak eklenebilir.

## Nasıl Çalıştırılır

1. Depoyu klonlayın.
2. Projeyi tercih ettiğiniz C# IDE'sinde açın.
3. Uygulamayı derleyin ve çalıştırın.

## Komutlar

- `durumekle` - Yeni bir durum ekle.
- `durumsil` - Mevcut bir durumu sil.
- `sonrakidurum` - Değişikliği bir sonraki duruma geçir.
- `itemekle` - Değişikliğe yeni bir öğe ekle.
- `itemsil` - Değişiklikten bir öğeyi sil.
- `sonrakiitemdurum` - Bir öğeyi bir sonraki duruma geçir.
- `exit` - Uygulamadan çık.

---

## Example Usage

```plaintext
Change Management Console Application
-------------------------------------
Change State: dev
Change Items:
+----+--------------------------+----------------+
| No | Change Item              | State          |
+----+--------------------------+----------------+
| 0  | Example Change Item 1    | dev            |
| 1  | Example Change Item 2    | dev            |
+----+--------------------------+----------------+

Enter a command:
