const sliderContainer = document.querySelector(".slider-container");
const sliderImgs = document.querySelectorAll(".slider__imgs");

function slideShow() {
   let i = 0;
   setInterval(() => {
      sliderContainer.style.transform = `translateX(calc(-690px * ${i}))`;
      i++;
      if (i === sliderImgs.length) {
         i = 0;
      }
   }, 3000);
}
slideShow();
