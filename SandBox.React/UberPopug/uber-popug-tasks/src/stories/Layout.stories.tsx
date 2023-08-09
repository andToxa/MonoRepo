import {Meta, StoryObj} from "@storybook/react";
import Layout from "../views/layout";

const meta = {
  title: "Example/Layout",
  component: Layout,
  tags: ["autodocs"],
} satisfies Meta<typeof Layout>;

export default meta;
type Story = StoryObj<typeof meta>;

export const Primary: Story = {};
