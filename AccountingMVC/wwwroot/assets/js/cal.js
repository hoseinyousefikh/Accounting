/*!
 * dashmix - v5.4.0
 * @author pixelcave - https://pixelcave.com
 * Copyright (c) 2022
 */
! function() {
    var t = {
            262: function() {
                FullCalendar.globalLocales.push(function() {
                    "use strict";
                    return {
                        code: "fa",
                        week: {
                            dow: 6,
                            doy: 12
                        },
                        direction: "rtl",
                        buttonText: {
                            prev: "قبلی",
                            next: "بعدی",
                            today: "امروز",
                            month: "ماه",
                            week: "هفته",
                            day: "روز",
                            list: "برنامه"
                        },
                        weekText: "هف",
                        allDayText: "تمام روز",
                        moreLinkText: function(t) {
                            return "بیش از " + t
                        },
                        noEventsText: "هیچ رویدادی به نمایش"
                    }
                }())
            }
        },
        e = {};

    function n(a) {
        var r = e[a];
        if (void 0 !== r) return r.exports;
        var l = e[a] = {
            exports: {}
        };
        return t[a](l, l.exports, n), l.exports
    }
    n.n = function(t) {
            var e = t && t.__esModule ? function() {
                return t.default
            } : function() {
                return t
            };
            return n.d(e, {
                a: e
            }), e
        }, n.d = function(t, e) {
            for (var a in e) n.o(e, a) && !n.o(t, a) && Object.defineProperty(t, a, {
                enumerable: !0,
                get: e[a]
            })
        }, n.o = function(t, e) {
            return Object.prototype.hasOwnProperty.call(t, e)
        },
        function() {
            "use strict";
            var t = n(262),
                e = n.n(t);
            Dashmix.onLoad((() => class {
                static addEvent() {
                    let t = document.querySelector(".js-add-event"),
                        e = "";
                    document.querySelector(".js-form-add-event").addEventListener("submit", (n => {
                        if (n.preventDefault(), e = t.value, e) {
                            let n = document.getElementById("js-events"),
                                a = document.createElement("li"),
                                r = document.createElement("div");
                            r.classList.add("js-event"), r.classList.add("p-2"), r.classList.add("fs-sm"), r.classList.add("fw-medium"), r.classList.add("rounded"), r.classList.add("bg-info-light"), r.classList.add("text-info"), r.textContent = e, a.appendChild(r), n.insertBefore(a, n.firstChild), t.value = ""
                        }
                    }))
                }
                static initEvents() {
                    new FullCalendar.Draggable(document.getElementById("js-events"), {
                        itemSelector: ".js-event",
                        eventData: function(t) {
                            return {
                                title: t.textContent,
                                backgroundColor: getComputedStyle(t).color,
                                borderColor: getComputedStyle(t).color
                            }
                        }
                    })
                }
                static initCalendar() {
                    let t = new Date,
                        n = t.getDate(),
                        a = t.getMonth(),
                        r = t.getFullYear(),
                        l = new FullCalendar.Calendar(document.getElementById("js-calendar"), {
                            themeSystem: "standard",
                            firstDay: 6,
                            editable: !0,
                            locales: [e()],
                            locale: "fa",
                            selectable: !0,
                            selectMirror: !0,
                            dayMaxEvents: !0,
                            dir: "rtl",
                            droppable: !0,
                            headerToolbar: {
                                left: "prev,next today dayGridMonth,timeGridWeek,timeGridDay,listWeek",
                                right: "title"
                            },
                            drop: function(t) {
                                t.draggedEl.parentNode.remove()
                            },
                            select: function(t) {
                                var e = prompt("عنوان رخداد:");
                                if (e) {
                                    const n = ["#e04f1a", "#82b54b", "#ffb119", "#82b54b", "#ffb119", "#3c90df"],
                                        a = Math.floor(Math.random() * n.length);
                                    console.log(a), l.addEvent({
                                        title: e,
                                        start: t.start,
                                        end: t.end,
                                        allDay: t.allDay,
                                        color: n[a]
                                    })
                                }
                                l.unselect()
                            },
                            eventClick: function(t) {
                                confirm("آیا شما مطمئن هستید که میخواهید این رویداد را حذف کنید؟") && t.event.remove()
                            },
                            events: [{
                                title: "روز بازی",
                                start: new Date(r, a, 1),
                                allDay: !0
                            }, {
                                title: "ملاقات اسکایپی",
                                start: new Date(r, a, 3)
                            }, {
                                title: "پروژه 1",
                                start: new Date(r, a, 9),
                                end: new Date(r, a, 12),
                                allDay: !0,
                                color: "#e04f1a"
                            }, {
                                title: "کار کردن",
                                start: new Date(r, a, 17),
                                end: new Date(r, a, 19),
                                allDay: !0,
                                color: "#82b54b"
                            }, {
                                id: 999,
                                title: "پیاده روی (تکرار)",
                                start: new Date(r, a, n - 1, 15, 0)
                            }, {
                                id: 999,
                                title: "پیاده روی (تکرار)",
                                start: new Date(r, a, n + 3, 15, 0)
                            }, {
                                title: "قالب لندینگ",
                                start: new Date(r, a, n - 3),
                                end: new Date(r, a, n - 3),
                                allDay: !0,
                                color: "#ffb119"
                            }, {
                                title: "ناهار",
                                start: new Date(r, a, n + 7, 15, 0),
                                color: "#82b54b"
                            }, {
                                title: "کدنویسی",
                                start: new Date(r, a, n, 8, 0),
                                end: new Date(r, a, n, 14, 0)
                            }, {
                                title: "سفر کردن",
                                start: new Date(r, a, 25),
                                end: new Date(r, a, 27),
                                allDay: !0,
                                color: "#ffb119"
                            }, {
                                title: "مطالعه",
                                start: new Date(r, a, n + 8, 20, 0),
                                end: new Date(r, a, n + 8, 22, 0)
                            }, {
                                title: "دنبال کردن در توییتر",
                                start: new Date(r, a, 22),
                                allDay: !0,
                                url: "http://twitter.com/",
                                color: "#3c90df"
                            }]
                        });
                    l.render()
                }
                static init() {
                    this.addEvent(), this.initEvents(), this.initCalendar()
                }
            }.init()))
        }()
}();