/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml',
    './Areas/Identity/Pages/**/*.cshtml'
  ],
  theme: {
    extend: {},
  },
  plugins: [
      require("daisyui"), 
      require('@tailwindcss/typography')
  ], 
  daisyui: {
    themes: ["corporate"]
  }
}

