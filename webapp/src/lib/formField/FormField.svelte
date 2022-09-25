<script lang="ts">
    import TextField, { Input } from '@smui/textfield';
    export let value = '';
</script>

<TextField bind:value={value}>

</TextField>

<style lang="scss">
    TextField {
        width: 100%;
    }
</style>
