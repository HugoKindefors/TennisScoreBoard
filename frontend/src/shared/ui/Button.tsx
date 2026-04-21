import type { ButtonHTMLAttributes } from "react";

type Variant = "primary" | "neutral" | "danger";

type ButtonProps = ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: Variant;
};

export function Button({
  variant = "primary",
  className,
  ...props
}: ButtonProps) {
  const classes = [
    "btn",
    variant === "danger"
      ? "btn-danger"
      : variant === "neutral"
        ? "btn-neutral"
        : "btn-primary",
    className,
  ]
    .filter(Boolean)
    .join(" ");

  return <button className={classes} {...props} />;
}
