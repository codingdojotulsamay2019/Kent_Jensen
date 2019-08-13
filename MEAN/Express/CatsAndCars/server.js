const express = require("express");
const app = express();
app.get('/', (request, response) => {
   response.send("Hello Express");
});
app.listen(8000, () => console.log("listening on port 8000"));
app.use(express.static(__dirname + "/static"));

app.get("/cats.html", (req, res) => {
   res.render('cats.html');
})
app.get("/cars.html", (req, res) => {
    res.render('cars.html');
})
app.get("/form.html", (req, res) => {
    res.render('form.html');
})