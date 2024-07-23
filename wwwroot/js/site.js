window.playSound = (soundUrl) => {
    if (window.currentAudio) {
        window.currentAudio.pause();
    }
    window.currentAudio = new Audio(soundUrl);
    window.currentAudio.play();
};

window.stopSound = () => {
    if (window.currentAudio) {
        window.currentAudio.pause();
        window.currentAudio.currentTime = 0;
    }
};

window.playVideoWithSound = (videoUrl, audioUrl) => {
    const videoElement = document.getElementById('video-player');
    if (window.currentAudio) {
        window.currentAudio.pause();
    }
    window.currentAudio = new Audio(audioUrl);
    window.currentAudio.loop = true;
    window.currentAudio.play();

    if (videoElement) {
        videoElement.src = videoUrl;
        videoElement.style.display = 'block'; // Ensure video is visible
        videoElement.play();
    } else {
        console.error('Video element not found');
    }
};
