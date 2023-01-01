const circleClick = (() => {
    const sliderButtons = Array.from(document.getElementsByClassName("slider__circle")); //lấy ra các nút
    sliderButtons.forEach((button, currentIndex) => {    //Mảng và tham số truyền vào
        button.addEventListener("click", () => {         //add event cho mảng các nút
            const sliderButtonActive = document.querySelector(".slider__circle.active")
            const imagesContainer = document.querySelector(".slider__images-container");
            let imagesContainerWidth = imagesContainer.offsetWidth;
            sliderButtonActive.classList.remove("active");   //Xóa class active(css)
            button.classList.add("active");                  //Thêm class acive(css)
            imagesContainer.style.transform = `translateX(-${imagesContainerWidth * currentIndex}px)`; //Chiều rộng ảnh * hàm số truyền vào
        });
    });
})();

const slideAutoPlay = (() => {
    const sliderButtons = Array.from(document.getElementsByClassName("slider__circle"));
    const imagesContainer = document.querySelector(".slider__images-container");
    let currentIndex = 0;
    setInterval(() => {
        let imagesContainerWidth = imagesContainer.offsetWidth;
        const sliderButtonActive = document.querySelector(".slider__circle.active")
        if (currentIndex == 2) currentIndex = -1;
        currentIndex++;
        sliderButtonActive.classList.remove("active");
        sliderButtons[currentIndex].classList.add("active");
        imagesContainer.style.transform = `translateX(-${imagesContainerWidth * currentIndex}px)`;
    }, 7500);
})();

const productsSlide = (() => {
    const productsLists = document.getElementsByClassName("products__slide-wrapper");
    let productsSlideWidth = document.querySelector(".products__slide").offsetWidth;
    const leftArrows = Array.from(document.getElementsByClassName("products__left-arrow"));
    const rightArrows = Array.from(document.getElementsByClassName("products__right-arrow"));
    let maxTimesToRight = [];
    let currentPosition = [];
    let productsWrapperWidth = document.querySelector(".products__wrapper").offsetWidth + 16; //Width+margin

    for (let i = 0; i < productsLists.length; ++i) {
        maxTimesToRight.push(Math.ceil((productsLists[i].offsetWidth - productsSlideWidth) / productsWrapperWidth)); //tối đa số lần sang phải
        currentPosition.push(0);
    }

    //Tính toán lại khi thay đổi kích thước
    window.addEventListener("resize", () => {
        maxTimesToRight = [];
        productsWrapperWidth = document.querySelector(".products__wrapper").offsetWidth + 16; //Width+margin
        productsSlideWidth = document.querySelector(".products__slide").offsetWidth;
        //Khi thu nhỏ, không thể nhấp chuột đến cuối slide => Tính toán lại maxTimesToRight khi thay đổi kích thước
        for (let i = 0; i < productsLists.length; ++i) {
            maxTimesToRight.push(Math.ceil((productsLists[i].offsetWidth - productsSlideWidth) / productsWrapperWidth));
        }
    });

    // Khi thu nhỏ, không thể nhấp chuột đến cuối slide =>
    // Tính toán lại maxTimesToRight khi thay đổi kích thước
    window.addEventListener("resize", () => {
        for (let i = 0; i < productsLists.length; ++i) {
            maxTimesToRight[i] = (Math.ceil((productsLists[i].offsetWidth - productsSlideWidth) / productsWrapperWidth));
        }
    });

    //RightArrows event
    rightArrows.forEach((rightArrow, index) => {
        rightArrow.addEventListener("click", (event) => {
            if (currentPosition[index] == maxTimesToRight[index] - 3)
                rightArrow.classList.add("disable"); //Thay đổi màu nút gọi đến class disable (css)

            if (currentPosition[index] >= maxTimesToRight[index]) { } //Ngăn giới hạn vượt quá giới hạn tối đa
            else {
                currentPosition[index]++;
                leftArrows[index].classList.remove("disable");
            }
            productsSlideToRight(productsLists[index], currentPosition[index], maxTimesToRight[index], productsWrapperWidth, event);
        });
    });

    //LeftArrows event
    leftArrows.forEach((leftArrow, index) => {
        if (currentPosition[index] == 0) leftArrow.classList.add("disable"); //Mặc định
        leftArrow.addEventListener("click", (event) => {
            if (currentPosition[index] == 1) leftArrow.classList.add("disable"); //Thay đổi màu leftArrow

            if (currentPosition[index] <= 0) { } //Ngăn chặn giới hạn xuống thấp hơn 0
            else {
                currentPosition[index]--;
                rightArrows[index].classList.remove("disable");
            }
            productsSlideToRight(productsLists[index], currentPosition[index], maxTimesToRight[index], productsWrapperWidth, event);
        });
    });
})();

const productsSlideToRight = (productsList, currentPosition, maxTimesToRight, productsWrapperWidth, event) => {
    if (currentPosition > maxTimesToRight || currentPosition < 0) {
        event.preventDefault();                                       //ngăn không cho click
    }
    else {
        productsList.style.transform = `translateX(-${productsWrapperWidth * currentPosition}px)`;
    }                                                                        //vị trí hiện tại
}