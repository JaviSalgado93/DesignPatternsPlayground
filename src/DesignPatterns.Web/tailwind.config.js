/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Pages/**/*.{razor,cshtml,html}",
        "./Shared/**/*. {razor,cshtml,html}",
        "./Layout/**/*.{razor,cshtml,html}",
        "./Components/**/*.{razor,cshtml,html}",
        ". /**/*.razor"
    ],
    theme: {
        extend: {
            colors: {
                // Tema Profesional - Azules y Grises
                primary: {
                    50: '#eff6ff',
                    100: '#dbeafe',
                    200: '#bfdbfe',
                    300: '#93c5fd',
                    400: '#60a5fa',
                    500: '#3b82f6',  // Azul principal
                    600: '#2563eb',  // Azul más oscuro (botones, links)
                    700: '#1d4ed8',
                    800: '#1e40af',
                    900: '#1e3a8a',
                },
                secondary: {
                    50: '#f8fafc',
                    100: '#f1f5f9',
                    200: '#e2e8f0',
                    300: '#cbd5e1',
                    400: '#94a3b8',
                    500: '#64748b',  // Gris medio
                    600: '#475569',
                    700: '#334155',
                    800: '#1e293b',  // Gris oscuro para texto
                    900: '#0f172a',  // Casi negro
                },
                accent: {
                    green: '#10b981',   // Verde para success
                    red: '#ef4444',     // Rojo para danger
                    yellow: '#f59e0b',  // Amarillo para warning
                    purple: '#8b5cf6',  // Púrpura para categorías
                }
            },
            fontFamily: {
                sans: ['Montserrat', 'ui-sans-serif', 'system-ui', 'sans-serif'],
            },
            spacing: {
                '18': '4.5rem',
                '88': '22rem',
                '100': '25rem',
            },
            maxWidth: {
                '8xl': '88rem',
            },
            animation: {
                'fade-in': 'fadeIn 0.5s ease-in-out',
                'slide-up': 'slideUp 0.5s ease-out',
                'slide-down': 'slideDown 0.3s ease-out',
            },
            keyframes: {
                fadeIn: {
                    '0%': { opacity: '0' },
                    '100%': { opacity: '1' },
                },
                slideUp: {
                    '0%': { transform: 'translateY(20px)', opacity: '0' },
                    '100%': { transform: 'translateY(0)', opacity: '1' },
                },
                slideDown: {
                    '0%': { transform: 'translateY(-10px)', opacity: '0' },
                    '100%': { transform: 'translateY(0)', opacity: '1' },
                },
            },
        },
    },
    plugins: [],
}