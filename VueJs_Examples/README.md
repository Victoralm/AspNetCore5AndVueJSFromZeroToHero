# [VueJs](https://vuejs.org/)

## [Interpolation](https://vuejs.org/v2/guide/syntax.html#Text)

Used to create dinamic fields with pure Js.

```html
<span><b>Message from attribute</b>: {{ msg }}</span>
<p><b>Message from method</b>: {{ hello() }}</p>

<script>
    ...
    data: {
        msg: "First VueJs interpolation.",
        description: "Some description text.",
    },
    methods: {
        hello: function() {
            return `${this.msg} ${this.description}`;
        },
    },
    ...
</script>

```

## [V-Bind](https://vuejs.org/v2/api/#v-bind)

Used to set html tags attributes, like the value of the `href` for a link or the
value of the `src` of an image for example.

```html
<a v-bind:href="link">Google</a>

<script>
    ...
    data: {
        link: "https://google.com",
        ...
</script>
```

## [V-Once](https://vuejs.org/v2/api/#v-once)

Prevent alterations of an attribute value within an HTML tag marked with v-once.

```html
<!-- Shows the original attribute text -->
<span v-once><b>Message from attribute</b>: {{ msg }}</span>

<!-- Shows the method alterated text -->
<p><b>Message from method</b>: {{ hello() }}</p>

<script>
    ...
    data: {
        msg: "First VueJs interpolation.",
        description: "Some description text.",
        ...
    },
    methods: {
        hello: function() {
            this.msg = "Hello";
            return `${this.msg} ${this.description}`;
        },
    ...
</script>
```

## [V-HTML](https://vuejs.org/v2/api/#v-html)

Used to pass fully HTML tags dinamically. For example, send an interpolated
attribute to be used as a link that will be placed inside a HTML tag.

```html
<p v-html="link2"></p>

<script>
    ...
    link2: '<a href="https://google.com">Google</a>',
    ...
</script>
```