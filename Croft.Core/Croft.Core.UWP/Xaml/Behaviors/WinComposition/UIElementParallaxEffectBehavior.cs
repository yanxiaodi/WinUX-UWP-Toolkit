// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UIElementParallaxEffectBehavior.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Behaviors.WinComposition
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Hosting;

    using Microsoft.Xaml.Interactivity;

    using WinUX.Extensions;

    public class UIElementParallaxEffectBehavior : Behavior
    {
        public static readonly DependencyProperty ParallaxElementProperty =
            DependencyProperty.Register(
                "ParallaxElement",
                typeof(UIElement),
                typeof(UIElementParallaxEffectBehavior),
                new PropertyMetadata(null, OnParallaxElementChanged));

        public static readonly DependencyProperty ParallaxMultiplierProperty =
            DependencyProperty.Register(
                "ParallaxMultiplier",
                typeof(double),
                typeof(UIElementParallaxEffectBehavior),
                new PropertyMetadata(0.3));

        public double ParallaxMultiplier
        {
            get
            {
                return (double)this.GetValue(ParallaxMultiplierProperty);
            }
            set
            {
                this.SetValue(ParallaxMultiplierProperty, value);
            }
        }

        private static void OnParallaxElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as UIElementParallaxEffectBehavior;
            behavior?.AttachParallaxEffect();
        }

        private void AttachParallaxEffect()
        {
            if (this.ParallaxElement != null && this.AssociatedObject != null)
            {
                var scrollViewer = this.AssociatedObject as ScrollViewer;
                if (scrollViewer == null)
                {
                    // Attempt to see if this is attached to a scroll-based control like a ListView or GridView.
                    scrollViewer = this.AssociatedObject.FindChildElementOfType<ScrollViewer>();

                    if (scrollViewer == null)
                    {
                        throw new InvalidOperationException(
                            "The associated object or one of it's child elements must be of type ScrollViewer.");
                    }
                }

                var compositionPropertySet =
                    ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);

                var compositor = compositionPropertySet.Compositor;

                var animationExpression = compositor.CreateExpressionAnimation(
                    "ScrollViewer.Translation.Y * Multiplier");

                animationExpression.SetScalarParameter("Multiplier", (float)this.ParallaxMultiplier);
                animationExpression.SetReferenceParameter("ScrollViewer", compositionPropertySet);

                var visual = ElementCompositionPreview.GetElementVisual(this.ParallaxElement);
                visual.StartAnimation("Offset.Y", animationExpression);
            }
        }

        public UIElement ParallaxElement
        {
            get
            {
                return (UIElement)this.GetValue(ParallaxElementProperty);
            }
            set
            {
                this.SetValue(ParallaxElementProperty, value);
            }
        }

        protected override void OnAttached()
        {
            this.AttachParallaxEffect();
        }
    }
}