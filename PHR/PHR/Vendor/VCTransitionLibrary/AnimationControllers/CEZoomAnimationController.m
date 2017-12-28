//
//  CEZoomAnimationController.m
//  TabBarDemo
//
//  Created by Luong Le Hoang on 7/14/16.
//  Copyright © 2016 Colin Eberhardt. All rights reserved.
//

#import "CEZoomAnimationController.h"

@implementation CEZoomAnimationController

- (id)init {
    if (self = [super init]) {
        
    }
    return self;
}

- (void)animateTransition:(id<UIViewControllerContextTransitioning>)transitionContext fromVC:(UIViewController *)fromVC toVC:(UIViewController *)toVC fromView:(UIView *)fromView toView:(UIView *)toView {
    
    // Add the toView to the container
    UIView* containerView = [transitionContext containerView];
    toView.frame = [transitionContext finalFrameForViewController:toVC];
    [containerView addSubview:toView];
    [containerView sendSubviewToBack:toView];
    
    
    fromView.transform = CGAffineTransformMakeScale(1., 1.);
    fromView.alpha = 0.6;
    // animate
    NSTimeInterval duration = [self transitionDuration:transitionContext];
    [UIView animateWithDuration:duration
                          delay:0
                        options:UIViewAnimationOptionCurveLinear
                     animations:^{
        fromView.transform = CGAffineTransformMakeScale(.6, .6);
        fromView.alpha = 0.0;
    } completion:^(BOOL finished) {
        if ([transitionContext transitionWasCancelled]) {
            fromView.alpha = 1.0;
            fromView.transform = CGAffineTransformMakeScale(1., 1.);
        } else {
            // reset from- view to its original state
            [fromView removeFromSuperview];
            fromView.alpha = 1.0;
            fromView.transform = CGAffineTransformMakeScale(1., 1.);
        }
        [transitionContext completeTransition:![transitionContext transitionWasCancelled]];
    }];
    
    toView.transform = CGAffineTransformMakeScale(0.6, 0.6);
    toView.alpha = 0.5;
    [UIView animateWithDuration:duration
                          delay:0
                        options:UIViewAnimationOptionCurveEaseOut
                     animations:^{
                         toView.alpha = 1.;
                         toView.transform = CGAffineTransformMakeScale(1.0, 1.0);
                     } completion:nil];
}

@end
