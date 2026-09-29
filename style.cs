/* =========================================================
   GENERAL
========================================================= */

* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

html {
    scroll-behavior: smooth;
}

body {
    font-family: "Inter", sans-serif;
    background: #050914;
    color: #ffffff;
    overflow-x: hidden;
}


/* =========================================================
   BACKGROUND
========================================================= */

.background {
    position: fixed;
    inset: 0;
    overflow: hidden;
    z-index: -1;
    pointer-events: none;
}

.background span {
    position: absolute;
    width: 250px;
    height: 250px;
    border-radius: 50%;
    background: rgba(0, 132, 255, 0.08);
    filter: blur(70px);
    animation: floating 10s infinite alternate ease-in-out;
}

.background span:nth-child(1) {
    top: 10%;
    left: 5%;
}

.background span:nth-child(2) {
    top: 50%;
    right: 10%;
    animation-delay: 2s;
}

.background span:nth-child(3) {
    bottom: 10%;
    left: 30%;
    animation-delay: 4s;
}

.background span:nth-child(4) {
    top: 20%;
    right: 30%;
    animation-delay: 6s;
}

.background span:nth-child(5) {
    bottom: 0;
    right: 50%;
    animation-delay: 8s;
}


@keyframes floating {

    from {
        transform: translate(0, 0) scale(1);
    }

    to {
        transform: translate(80px, -60px) scale(1.3);
    }

}


/* =========================================================
   NAVIGATION
========================================================= */

.navbar {

    position: fixed;

    top: 0;
    left: 0;

    width: 100%;

    padding: 20px 7%;

    display: flex;

    justify-content: space-between;
    align-items: center;

    background: rgba(5, 9, 20, 0.8);

    backdrop-filter: blur(20px);

    border-bottom: 1px solid rgba(0, 140, 255, 0.12);

    z-index: 1000;

}


.logo {

    font-size: 25px;

    font-weight: 800;

    letter-spacing: 2px;

}


.logo span {

    color: #168cff;

}


.navbar nav {

    display: flex;

    gap: 35px;

}


.navbar nav a {

    color: #cbd5e1;

    text-decoration: none;

    font-size: 15px;

    transition: 0.3s;

}


.navbar nav a:hover {

    color: #168cff;

}


.menu-btn {

    display: none;

    background: transparent;

    border: none;

    color: white;

    font-size: 25px;

}


/* =========================================================
   HERO
========================================================= */

.hero {

    min-height: 100vh;

    display: flex;

    align-items: center;

    padding: 120px 7% 60px;

}


.hero-content {

    width: 100%;

    display: flex;

    align-items: center;

    justify-content: center;

    gap: 90px;

}


.profile-container {

    position: relative;

    width: 270px;

    height: 270px;

    flex-shrink: 0;

}


.profile-container::before {

    content: "";

    position: absolute;

    inset: -10px;

    border: 2px solid #168cff;

    border-radius: 50%;

    animation: rotateBorder 8s linear infinite;

}


@keyframes rotateBorder {

    to {
        transform: rotate(360deg);
    }

}


.profile-container img {

    width: 100%;
    height: 100%;

    object-fit: cover;

    border-radius: 50%;

    border: 7px solid #080d19;

    box-shadow:
        0 0 30px rgba(0, 132, 255, 0.4);

}


.profile-edit {

    position: absolute;

    right: 5px;
    bottom: 15px;

    width: 50px;
    height: 50px;

    border-radius: 50%;

    background: #168cff;

    display: flex;

    justify-content: center;
    align-items: center;

    cursor: pointer;

    font-size: 20px;

    transition: 0.3s;

}


.profile-edit:hover {

    transform: scale(1.1);

    background: #0069ca;

}


.hero-text {

    max-width: 700px;

}


.small-title {

    color: #168cff;

    font-size: 14px;

    font-weight: 700;

    letter-spacing: 4px;

    margin-bottom: 15px;

}


.hero h1 {

    font-size: clamp(45px, 7vw, 85px);

    line-height: 1;

    margin-bottom: 20px;

}


.hero h1 span {

    display: block;

    color: transparent;

    -webkit-text-stroke: 1px #168cff;

}


.hero h2 {

    color: #dbeafe;

    font-size: 25px;

    min-height: 35px;

}


.hero-text > p {

    color: #94a3b8;

    line-height: 1.8;

    margin: 20px 0 30px;

    max-width: 600px;

}


.main-btn {

    display: inline-flex;

    align-items: center;

    gap: 15px;

    padding: 15px 25px;

    border-radius: 8px;

    background: #168cff;

    color: white;

    text-decoration: none;

    font-weight: 700;

    transition: 0.3s;

}


.main-btn:hover {

    transform: translateY(-4px);

    box-shadow:
        0 10px 30px rgba(0, 140, 255, 0.3);

}


/* =========================================================
   SECTIONS
========================================================= */

.section {

    padding: 110px 7%;

}


.section-title {

    text-align: center;

    margin-bottom: 50px;

}


.section-title p {

    color: #168cff;

    font-size: 13px;

    letter-spacing: 3px;

    font-weight: 700;

    margin-bottom: 10px;

}


.section-title h2 {

    font-size: 45px;

}


.section-title h2 span {

    color: #168cff;

}


/* =========================================================
   ABOUT
========================================================= */

.about-card {

    max-width: 1000px;

    margin: auto;

    padding: 40px;

    display: flex;

    gap: 30px;

    border: 1px solid rgba(0, 140, 255, 0.2);

    background: rgba(10, 18, 35, 0.75);

    border-radius: 20px;

    transition: 0.4s;

}


.about-card:hover {

    transform: translateY(-8px);

    border-color: rgba(0, 140, 255, 0.6);

    box-shadow:
        0 20px 50px rgba(0, 100, 255, 0.1);

}


.about-icon {

    min-width: 70px;
    height: 70px;

    display: flex;

    justify-content: center;
    align-items: center;

    background: #168cff;

    border-radius: 15px;

    font-size: 22px;

    font-weight: 800;

}


.about-card h3 {

    font-size: 25px;

    margin-bottom: 15px;

}


.about-card p {

    color: #94a3b8;

    line-height: 1.8;

    margin-bottom: 15px;

}


.skills {

    display: flex;

    flex-wrap: wrap;

    gap: 10px;

    margin-top: 20px;

}


.skills span {

    padding: 8px 13px;

    background: rgba(22, 140, 255, 0.1);

    border: 1px solid rgba(22, 140, 255, 0.3);

    color: #70b7ff;

    border-radius: 50px;

    font-size: 13px;

}


/* =========================================================
   CATEGORY BUTTONS
========================================================= */

.category-buttons {

    display: flex;

    justify-content: center;

    flex-wrap: wrap;

    gap: 12px;

    margin-bottom: 35px;

}


.category-btn {

    padding: 12px 20px;

    border-radius: 50px;

    border: 1px solid #1e3a5f;

    background: #0a1220;

    color: #94a3b8;

    cursor: pointer;

    font-family: inherit;

    transition: 0.3s;

}


.category-btn:hover {

    border-color: #168cff;

    color: white;

}


.category-btn.active {

    background: #168cff;

    border-color: #168cff;

    color: white;

    box-shadow:
        0 5px 20px rgba(0, 140, 255, 0.25);

}


/* =========================================================
   UPLOAD
========================================================= */

.upload-card {

    max-width: 1000px;

    margin: auto;

    padding: 25px;

    display: flex;

    justify-content: space-between;

    align-items: center;

    gap: 20px;

    background: rgba(10, 18, 35, 0.8);

    border: 1px solid #173456;

    border-radius: 15px;

}


.upload-card h3 {

    font-size: 22px;

}


.upload-card p {

    color: #64748b;

    margin-top: 6px;

}


.upload-btn {

    background: #168cff;

    padding: 13px 20px;

    border-radius: 8px;

    cursor: pointer;

    font-weight: 700;

    transition: 0.3s;

    white-space: nowrap;

}


.upload-btn:hover {

    background: #0069ca;

    transform: translateY(-2px);

}


/* =========================================================
   COUNTER
========================================================= */

.counter {

    max-width: 1000px;

    margin: 25px auto;

    display: flex;

    gap: 15px;

}


.counter div {

    flex: 1;

    padding: 20px;

    text-align: center;

    border-radius: 12px;

    background: #0a1220;

    border: 1px solid #173456;

}


.counter strong {

    display: block;

    font-size: 28px;

    color: #168cff;

}


.counter span {

    color: #64748b;

    font-size: 13px;

}


/* =========================================================
   FILE GRID
========================================================= */

.file-grid {

    max-width: 1000px;

    margin: 30px auto;

    display: grid;

    grid-template-columns:
        repeat(auto-fill, minmax(220px, 1fr));

    gap: 20px;

}


.file-card {

    overflow: hidden;

    background: #0a1220;

    border: 1px solid #173456;

    border-radius: 15px;

    animation: cardAppear 0.5s ease;

}


@keyframes cardAppear {

    from {

        opacity: 0;

        transform: translateY(20px);

    }

    to {

        opacity: 1;

        transform: translateY(0);

    }

}


.file-preview {

    height: 160px;

    display: flex;

    align-items: center;

    justify-content: center;

    background: #060b14;

    overflow: hidden;

}


.file-preview img {

    width: 100%;
    height: 100%;

    object-fit: cover;

}


.file-icon {

    font-size: 55px;

}


.file-info {

    padding: 15px;

}


.file-info h4 {

    font-size: 14px;

    white-space: nowrap;

    overflow: hidden;

    text-overflow: ellipsis;

}


.file-info p {

    font-size: 12px;

    color: #64748b;

    margin-top: 6px;

}


.file-actions {

    display: flex;

    gap: 8px;

    margin-top: 12px;

}


.file-actions a {

    flex: 1;

    padding: 9px;

    text-align: center;

    text-decoration: none;

    color: white;

    background: #168cff;

    border-radius: 6px;

    font-size: 12px;

}


.empty {

    grid-column: 1 / -1;

    padding: 60px;

    text-align: center;

    color: #475569;

}


/* =========================================================
   FOOTER
========================================================= */

footer {

    padding: 50px 7%;

    text-align: center;

    border-top: 1px solid #17253a;

}


.footer-logo {

    font-size: 25px;

    font-weight: 800;

    color: #168cff;

    margin-bottom: 15px;

}


footer p {

    color: #64748b;

    margin: 7px;

}


.copyright {

    font-size: 12px;

}


/* =========================================================
   RESPONSIVE
========================================================= */

@media (max-width: 850px) {

    .navbar {

        padding: 18px 5%;

    }


    .navbar nav {

        position: absolute;

        top: 70px;

        left: 5%;

        right: 5%;

        padding: 20px;

        display: none;

        flex-direction: column;

        gap: 20px;

        background: #0a1220;

        border: 1px solid #173456;

        border-radius: 12px;

    }


    .navbar nav.show {

        display: flex;

    }


    .menu-btn {

        display: block;

    }


    .hero {

        padding-left: 5%;
        padding-right: 5%;

    }


    .hero-content {

        flex-direction: column;

        text-align: center;

        gap: 50px;

    }


    .hero-text > p {

        margin-left: auto;
        margin-right: auto;

    }


    .section {

        padding-left: 5%;
        padding-right: 5%;

    }


    .about-card {

        flex-direction: column;

    }


    .about-icon {

        width: 70px;

    }


    .upload-card {

        flex-direction: column;

        align-items: stretch;

    }


    .upload-btn {

        text-align: center;

    }

}


@media (max-width: 500px) {

    .profile-container {

        width: 210px;
        height: 210px;

    }


    .hero h1 {

        font-size: 45px;

    }


    .hero h2 {

        font-size: 20px;

    }


    .section-title h2 {

        font-size: 35px;

    }


    .counter {

        flex-direction: column;

    }


    .file-grid {

        grid-template-columns: 1fr;

    }

}