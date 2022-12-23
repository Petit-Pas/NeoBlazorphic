/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./**/*.{razor,html,cshtml,cs}"],
    theme: {
        extend: {
            boxShadow: {
                'neo-out': '5px 5px 10px var(--dark-shadow), -5px -5px 10px var(--light-shadow)',
                'neo-in': 'inset 5px 5px 10px var(--alternate-dark-shadow), inset -5px -5px 10px var(--alternate-light-shadow)'
            },
        },
    },
    safelist: [
        'rounded-md',
        'rounded-full'
    ],
    plugins: [],
}
