window.registerHoverEffect = () => {
    document.querySelectorAll('.attachment-wrapper').forEach(wrapper => {
        wrapper.addEventListener('mouseover', () => {
            wrapper.querySelector('.remove-btn').style.display = 'block';
        });
        wrapper.addEventListener('mouseout', () => {
            wrapper.querySelector('.remove-btn').style.display = 'none';
        });
    });
};