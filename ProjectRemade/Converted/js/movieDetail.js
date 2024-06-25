let slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
//   showSlides(slideIndex += n);
    const slide = document.getElementsByClassName("date-picker")[0];
    const prev= document.getElementsByClassName("prev")[0];
    const next= document.getElementsByClassName("next")[0];
    if(n < 0) {
      console.log(slide.scrollLeft.toFixed() - 50);
      slide.scrollTo(0,0);
    }

    slide.scrollLeft +=50;
}

// Thumbnail image controls
function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  let i;
  let slides = document.getElementsByClassName("date-picker-a");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "incline-block";
  }
  
  slides[slideIndex-1].style.display = "incline-block";

}
