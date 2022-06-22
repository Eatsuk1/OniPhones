const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);

const selectBox1 = $$(".section2_selectBox1");
const selectBox2 = $$(".section2_selectBox2");

console.log(selectBox1);
console.log(selectBox2);

selectBox1.forEach((box, index) => {
    box.onclick = function () {
        $(".section2_selectBox1.active").classList.remove("active");
        this.classList.add("active");
    };
});

selectBox2.forEach((box, index) => {
    box.onclick = function () {
        $(".section2_selectBox2.active").classList.remove("active");
        this.classList.add("active");
    };
});
