/* =========================================================
   PORTFOLIO JAVASCRIPT
========================================================= */


/* =========================================================
   MOBILE MENU
========================================================= */

const menuBtn = document.getElementById("menuBtn");

const navMenu = document.getElementById("navMenu");


menuBtn.addEventListener("click", () => {

    navMenu.classList.toggle("show");

});


/* =========================================================
   TYPING ANIMATION
========================================================= */

const typingText = document.getElementById("typingText");

const textList = [

    "Computer Science Student",

    "Future Software Developer",

    "Web Developer",

    "Programming Learner",

    "Technology Enthusiast"

];


let textIndex = 0;

let characterIndex = 0;

let deleting = false;


function typingAnimation() {

    const currentText = textList[textIndex];

    if (!deleting) {

        typingText.textContent =
            currentText.substring(0, characterIndex + 1);

        characterIndex++;

        if (characterIndex === currentText.length) {

            deleting = true;

            setTimeout(typingAnimation, 1800);

            return;

        }

    } else {

        typingText.textContent =
            currentText.substring(0, characterIndex - 1);

        characterIndex--;

        if (characterIndex === 0) {

            deleting = false;

            textIndex++;

            if (textIndex >= textList.length) {

                textIndex = 0;

            }

        }

    }

    setTimeout(
        typingAnimation,
        deleting ? 50 : 100
    );

}


typingAnimation();


/* =========================================================
   PROFILE PICTURE
========================================================= */

const profileUpload =
    document.getElementById("profileUpload");

const profileImage =
    document.getElementById("profileImage");


profileUpload.addEventListener("change", function () {

    const file = this.files[0];

    if (!file) return;

    if (!file.type.startsWith("image/")) {

        alert("Please select an image.");

        return;

    }

    const reader = new FileReader();

    reader.onload = function (event) {

        profileImage.src = event.target.result;

        localStorage.setItem(
            "profileImage",
            event.target.result
        );

    };

    reader.readAsDataURL(file);

});


/* LOAD SAVED PROFILE */

const savedProfile =
    localStorage.getItem("profileImage");


if (savedProfile) {

    profileImage.src = savedProfile;

}


/* =========================================================
   CATEGORIES
========================================================= */

let currentCategory = "quiz";


const categoryNames = {

    quiz: "Quiz",

    longquiz: "Long Quiz",

    midterms: "Midterms",

    finals: "Finals",

    activities: "Activities",

    projects: "Projects"

};


const categoryButtons =
    document.querySelectorAll(".category-btn");


categoryButtons.forEach(button => {

    button.addEventListener("click", () => {

        categoryButtons.forEach(btn => {

            btn.classList.remove("active");

        });

        button.classList.add("active");

        currentCategory =
            button.dataset.category;

        document.getElementById(
            "currentCategory"
        ).textContent =
            categoryNames[currentCategory];

        loadFiles();

    });

});


/* =========================================================
   FILE UPLOAD
========================================================= */

const fileUpload =
    document.getElementById("fileUpload");


fileUpload.addEventListener("change", async function () {

    const files = Array.from(this.files);

    if (files.length === 0) return;


    /*
    Check Firebase
    */

    if (
        !window.firebaseStorage ||
        !window.firebaseDB
    ) {

        alert(
            "Firebase is not configured yet. Add your Firebase configuration in index.html."
        );

        return;

    }


    const {
        collection,
        addDoc,
        ref,
        uploadBytes,
        getDownloadURL
    } = window.firebaseFunctions;


    try {

        for (const file of files) {

            const safeName =
                Date.now() +
                "_" +
                file.name.replace(
                    /[^a-zA-Z0-9._-]/g,
                    "_"
                );


            const storageRef = ref(

                window.firebaseStorage,

                `portfolio/${currentCategory}/${safeName}`

            );


            /* Upload */

            const snapshot =
                await uploadBytes(
                    storageRef,
                    file
                );


            /* Get public URL */

            const downloadURL =
                await getDownloadURL(
                    snapshot.ref
                );


            /* Save metadata */

            await addDoc(

                collection(
                    window.firebaseDB,
                    "portfolioFiles"
                ),

                {

                    name: file.name,

                    category: currentCategory,

                    type: file.type,

                    size: file.size,

                    url: downloadURL,

                    createdAt: Date.now()

                }

            );

        }


        alert(
            `${files.length} file(s) uploaded successfully!`
        );


        this.value = "";

        loadFiles();


    } catch (error) {

        console.error(error);

        alert(
            "Upload failed. Check your Firebase configuration and Storage rules."
        );

    }

});


/* =========================================================
   LOAD FILES
========================================================= */

async function loadFiles() {

    const fileGrid =
        document.getElementById("fileGrid");


    fileGrid.innerHTML = `
        <div class="empty">
            Loading files...
        </div>
    `;


    if (
        !window.firebaseDB ||
        !window.firebaseFunctions
    ) {

        fileGrid.innerHTML = `
            <div class="empty">
                Firebase has not been configured yet.
            </div>
        `;

        updateCounters([]);

        return;

    }


    try {

        const {
            collection,
            getDocs
        } = window.firebaseFunctions;


        const querySnapshot =
            await getDocs(

                collection(
                    window.firebaseDB,
                    "portfolioFiles"
                )

            );


        let files = [];


        querySnapshot.forEach(doc => {

            const data = doc.data();


            if (
                data.category === currentCategory
            ) {

                files.push({

                    id: doc.id,

                    ...data

                });

            }

        });


        files.sort(
            (a, b) =>
                (b.createdAt || 0) -
                (a.createdAt || 0)
        );


        displayFiles(files);


    } catch (error) {

        console.error(error);


        fileGrid.innerHTML = `
            <div class="empty">
                Unable to load files.
            </div>
        `;

    }

}


/* =========================================================
   DISPLAY FILES
========================================================= */

function displayFiles(files) {

    const fileGrid =
        document.getElementById("fileGrid");


    fileGrid.innerHTML = "";


    if (files.length === 0) {

        fileGrid.innerHTML = `

            <div class="empty">

                No files uploaded in this category yet.

            </div>

        `;

        updateCounters([]);

        return;

    }


    files.forEach(file => {

        const card =
            document.createElement("div");


        card.className = "file-card";


        const isImage =
            file.type &&
            file.type.startsWith("image/");


        const preview =
            isImage

            ?

            `
            <div class="file-preview">

                <img
                    src="${file.url}"
                    alt="${escapeHTML(file.name)}"
                >

            </div>
            `

            :

            `
            <div class="file-preview">

                <div class="file-icon">
                    📄
                </div>

            </div>
            `;


        card.innerHTML = `

            ${preview}

            <div class="file-info">

                <h4 title="${escapeHTML(file.name)}">
                    ${escapeHTML(file.name)}
                </h4>

                <p>
                    ${formatBytes(file.size)}
                </p>

                <div class="file-actions">

                    <a
                        href="${file.url}"
                        target="_blank"
                        rel="noopener"
                    >
                        View
                    </a>

                    <a
                        href="${file.url}"
                        download
                        target="_blank"
                        rel="noopener"
                    >
                        Download
                    </a>

                </div>

            </div>

        `;


        fileGrid.appendChild(card);

    });


    updateCounters(files);

}


/* =========================================================
   COUNTERS
========================================================= */

function updateCounters(files) {

    const fileCount =
        document.getElementById("fileCount");

    const imageCount =
        document.getElementById("imageCount");


    fileCount.textContent =
        files.length;


    const images =
        files.filter(
            file =>
                file.type &&
                file.type.startsWith("image/")
        );


    imageCount.textContent =
        images.length;

}


/* =========================================================
   FORMAT FILE SIZE
========================================================= */

function formatBytes(bytes) {

    if (!bytes) return "Unknown size";


    const units = [
        "Bytes",
        "KB",
        "MB",
        "GB"
    ];


    const index =
        Math.floor(
            Math.log(bytes) /
            Math.log(1024)
        );


    return (
        parseFloat(
            (bytes /
                Math.pow(
                    1024,
                    index
                )
            ).toFixed(2)
        ) +
        " " +
        units[index]
    );

}


/* =========================================================
   SECURITY HELPER
========================================================= */

function escapeHTML(text) {

    return String(text)

        .replace(
            /&/g,
            "&amp;"
        )

        .replace(
            /</g,
            "&lt;"
        )

        .replace(
            />/g,
            "&gt;"
        )

        .replace(
            /"/g,
            "&quot;"
        )

        .replace(
            /'/g,
            "&#039;"
        );

}


/* =========================================================
   INITIAL LOAD
========================================================= */

window.addEventListener(
    "DOMContentLoaded",
    () => {

        loadFiles();

    }
);