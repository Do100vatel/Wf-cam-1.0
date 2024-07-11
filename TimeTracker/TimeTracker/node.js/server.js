const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');
const path = require('path');

const app = express();
const dbPath = path.resolve(__dirname, 'C:\Users\games\source\repos\TimeTracker\TimeTracker\node.js\time_tracker.db'); // Путь к файлу базы данных
const db = new sqlite3.Database(dbPath); // Используем файл базы данных

app.use(bodyParser.json());

db.serialize(() => {
    // Создание таблиц для хранения данных о времени и категориях, если они не существуют
    db.run("CREATE TABLE IF NOT EXISTS TimeEntries (id INTEGER PRIMARY KEY AUTOINCREMENT, category TEXT, timeSpent REAL)");
    db.run("CREATE TABLE IF NOT EXISTS Categories (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT)");

    // Обработка POST-запросов для сохранения времени
    app.post('/saveTime', (req, res) => {
        const { category, timeSpent } = req.body;
        db.run("INSERT INTO TimeEntries (category, timeSpent) VALUES (?, ?)", [category, timeSpent], function(err) {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.status(200).send(`Entry added with ID: ${this.lastID}`);
        });
    });

    // Обработка GET-запросов для получения категорий
    app.get('/categories', (req, res) => {
        db.all("SELECT name FROM Categories", [], (err, rows) => {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.json(rows.map(row => row.name));
        });
    });

    // Обработка POST-запросов для добавления категории
    app.post('/addCategory', (req, res) => {
        const { name } = req.body;
        db.run("INSERT INTO Categories (name) VALUES (?)", [name], function(err) {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.status(200).send(`Category added with ID: ${this.lastID}`);
        });
    });

    // Обработка DELETE-запросов для удаления категории
    app.post('/removeCategory', (req, res) => {
        const { name } = req.body;
        db.run("DELETE FROM Categories WHERE name = ?", [name], function(err) {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.status(200).send("Category removed");
        });
    });

    // Обработка DELETE-запросов для очистки данных о времени
    app.delete('/clearTimeEntries', (req, res) => {
        db.run("DELETE FROM TimeEntries", function(err) {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.status(200).send("Time entries cleared");
        });
    });

    // Запуск сервера
    app.listen(3000, () => {
        console.log('Server is running on port 3000');
    });
});
