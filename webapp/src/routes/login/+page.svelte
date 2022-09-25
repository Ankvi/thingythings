<script lang="ts">
    import Paper, { Title, Content } from '@smui/paper';
    import TextField from '@smui/textfield';
    import HelperText from '@smui/textfield/helper-text';
    import Icon from '@smui/textfield/icon';
    import Button, { Label } from '@smui/button';
	import type { ActionData } from '.svelte-kit/types/src/routes/register/$types';

    let email = '';
    let password = '';

    // export let form: ActionData;
</script>

<Paper style="width:min-content; align-self:center;">
    <Title align="center" style="margin-bottom:1rem;">Sign up</Title>
    <Content>
        <form
            class="loginForm"
            method="post"
            action="?/login">
            <TextField class="formField" input$name="email" variant="outlined" bind:value={email} label="Email">
                <Icon class="material-icons" slot="leadingIcon">email</Icon>
                <HelperText slot="helper">john.smith@example.com</HelperText>
            </TextField>
            <TextField class="formField" input$name="password" type="password" variant="outlined" bind:value={password} label="Password">
                <Icon class="material-icons" slot="leadingIcon">password</Icon>
            </TextField>
            <div style="width: 100%;">
                <Button class="formButton" defaultAction variant="raised">
                    <Label>Log in</Label>
                </Button>
                <Button class="formButton" href="/register" variant="raised">
                    <Label>Sign up</Label>
                </Button>
            </div>
        </form>
    </Content>
</Paper>

<style lang="scss">
    * {
        :global(.formField) {
            width: 100%;
            min-width: 20rem;
        }

        :global(.formField:not(:first-child)) {
            margin-top: 0.5rem;
        }

        :global(.formButton) {
            width: 100%;
            margin-top: 0.5rem;
        }

    }
</style>
