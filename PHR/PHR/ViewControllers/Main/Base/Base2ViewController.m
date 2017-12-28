//
//  Bae2ViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "Base2NavigationBar.h"
#import "ListDiapersViewController.h"
#import "WebviewController.h"
#import "BaseHomeViewController.h"
#import "CustomPopTransition.h"
#import "LocalStorageImage.h"
#import "Base2NavigationBarRightIcon.h"
#import "FamilyListViewController.h"
#import "StandardHomeViewController.h"
#import "StandardFitnessDetailViewController.h"
#import "ChildrenHomeViewController.h"
#import "StandardFoodDetailViewController.h"
#import "StandardVitalsDetailViewController.h"
#import "BabyMilkViewController.h"
#import "ChildrenMedicinesViewController.h"
#import "BabyFoodDetailViewController.h"
#import "PHRBabySleepViewController.h"
#import "BabyGrowthDetailViewController.h"
#import <PureLayout/PureLayout.h>

@interface Base2ViewController ()<UINavigationControllerDelegate, UIGestureRecognizerDelegate>

@property (nonatomic, strong) UIPercentDrivenInteractiveTransition *interactivePopTransition;
@property (nonatomic, strong) UIView *viewPop;

@end

@implementation Base2ViewController {
    
}

- (instancetype)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil {
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        
    }
    return self;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    [self addSwipeGesture];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
    
    __weak __typeof(self) weakSelf = self;
    self.navigationController.delegate = weakSelf;
}

-(void) viewWillDisappear:(BOOL) animated {
    [super viewWillDisappear:animated];
    if ([self isMovingFromParentViewController])
    {
        if (self.navigationController.delegate == self)
        {
            self.navigationController.delegate = nil;
        }
    }
}

- (void)addSwipeGesture {
    self.popRecognizer = [[UIPanGestureRecognizer alloc] initWithTarget:self action:@selector(handlePopRecognizer:)];
    self.viewPop = [[UIView alloc] initWithFrame:CGRectMake(0, 0, 20, 2 * self.view.frame.size.height)];
    [self.view addSubview:self.viewPop];
    [self.viewPop addGestureRecognizer:self.popRecognizer];
}

- (void)handlePopRecognizer:(UIPanGestureRecognizer*)recognizer {
    CGFloat progress = [recognizer translationInView:self.view].x / (self.view.bounds.size.width * 1.0);
    progress = MIN(1.0, MAX(0.0, progress));
    
    if (recognizer.state == UIGestureRecognizerStateBegan) {
        CGPoint velocity = [recognizer velocityInView:self.view];
        if(velocity.x > 0) {
            self.interactivePopTransition = [[UIPercentDrivenInteractiveTransition alloc] init];
            [self.navigationController popViewControllerAnimated:YES];
        }
    }
    else if (recognizer.state == UIGestureRecognizerStateChanged) {
        [self.interactivePopTransition updateInteractiveTransition:progress];
    }
    else if (recognizer.state == UIGestureRecognizerStateEnded || recognizer.state == UIGestureRecognizerStateCancelled) {
        if (progress > 0.5) {
            [self.interactivePopTransition finishInteractiveTransition];
        }
        else {
            [self.interactivePopTransition cancelInteractiveTransition];
        }
        self.interactivePopTransition = nil;
    }
}

/*
 Setup navigation bar for Add viewcontroller
 */
- (void)setupNavigationBarTitle:(NSString *)title titleIcon:(NSString *)titleIcon rightItem:(NSString *)rightItem {
    __weak __typeof__(self) weakSelf = self;
    
    // Custom navigation bar
    self.navBar = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([Base2NavigationBar class]) owner:self options:nil] objectAtIndex:0];
    [self.navBar setupWithTitle:title icon:titleIcon rightItem:rightItem];
    [self.view addSubview:self.navBar];
    
    [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.navBar autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.navBar autoSetDimension:ALDimensionHeight toSize:60];
    // back
    [self.navBar setActionBack:^(){
        [weakSelf.navigationController popViewControllerAnimated:YES];
    }];
    
    // right action
    [self.navBar setActionRight:^(){
        [weakSelf actionNavigationBarItemRight];
    }];
}

- (void)setupNavigationBarTitle:(NSString *)title iconLeft:(NSString *)iconLeft iconRight:(NSString *)iconRight iconMiddle:(NSString*)iconMiddle isDismissView:(bool) isDismiss colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor {
    __weak __typeof__(self) weakSelf = self;
    
    // Custom navigation bar
    self.navBarRightIcon = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([Base2NavigationBarRightIcon class]) owner:self options:nil] objectAtIndex:0];
    [self.navBarRightIcon setupWithTitle:title iconLeft:iconLeft iconRight:iconRight iconMiddle:iconMiddle colorLeft:leftColor colorRight:rightColor];

    [self.view addSubview:self.navBarRightIcon];
    
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.navBarRightIcon autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.navBarRightIcon autoSetDimension:ALDimensionHeight toSize:60];
    
    // back
    [self.navBarRightIcon setActionBack:^(){
        if (isDismiss) {
            [weakSelf dismissViewControllerAnimated:YES completion:nil];
        } else {
            [weakSelf.navigationController popViewControllerAnimated:YES];
        }
    }];
    __block typeof(self) safeBlock = self;
    // right action
    [self.navBarRightIcon setActionRight:^(){
        
        if ([safeBlock isMemberOfClass:[FamilyListViewController class]]) {
            return;
        }
        FamilyListViewController *family = [[FamilyListViewController alloc] initWithNibName:NSStringFromClass([FamilyListViewController class]) bundle:nil];
        if ([safeBlock isMemberOfClass:[StandardHomeViewController class]] ||
            [safeBlock isMemberOfClass:[StandardFitnessDetailViewController class]] ||
            [safeBlock isMemberOfClass:[StandardFoodDetailViewController class]] ||
            [safeBlock isMemberOfClass:[StandardVitalsDetailViewController class]]) {
            family.type = PHRGroupTypeStandard;
        }
        else if ([safeBlock isMemberOfClass:[ChildrenHomeViewController class]]
                 || [safeBlock isMemberOfClass:[BabyMilkViewController class]]
                 || [safeBlock isMemberOfClass:[BabyFoodDetailViewController class]]
                 || [safeBlock isMemberOfClass:[BabyGrowthDetailViewController class]]
                 || [safeBlock isMemberOfClass:[ChildrenMedicinesViewController class]]
                 || [safeBlock isMemberOfClass:[ListDiapersViewController class]]
                 || [safeBlock isMemberOfClass:[PHRBabySleepViewController class]]) {
            family.type = PHRGroupTypeBaby;
        }
        [safeBlock.navigationController pushViewController:family animated:YES];
        //[weakSelf actionNavigationBarItemRight];
    }];
}



- (void)setEnableForRightButton:(BOOL) isEnable {
    [self.navBar setEnableForRightButton:isEnable];
}


- (id<UIViewControllerAnimatedTransitioning>)navigationController:(UINavigationController *)navigationController animationControllerForOperation:(UINavigationControllerOperation)operation fromViewController:(UIViewController *)fromVC toViewController:(UIViewController *)toVC {
    NSArray *viewControllers = self.navigationController.viewControllers;
    if ([viewControllers indexOfObject:self] == NSNotFound) {
        if ((fromVC == self && [toVC isKindOfClass:[BaseHomeViewController class]]) || (fromVC == self && [toVC isKindOfClass:[Base2ViewController class]])) {
            return [[CustomPopTransition alloc] init];
        }
        else {
            return nil;
        }
    }
    return nil;
}

- (id<UIViewControllerInteractiveTransitioning>)navigationController:(UINavigationController *)navigationController interactionControllerForAnimationController:(id<UIViewControllerAnimatedTransitioning>)animationController {
    
    if ([animationController isKindOfClass:[CustomPopTransition class]]) {
        return self.interactivePopTransition;
    }
    else {
        return nil;
    }
}

#pragma mark - UI Actions
// ----------------------------------- UI Actions ----------------------------------
- (void)actionNavigationBarItemRight {
    // Just for @override
    [self.navigationController popViewControllerAnimated:YES];
}

- (void)showImage:(UIImageView *)imageView {
    PHRShowImageViewController *showImg = [[PHRShowImageViewController alloc] initWithNibName:NSStringFromClass([PHRShowImageViewController class]) bundle:nil];
    showImg.imageView = imageView;
    [self.navigationController pushViewController:showImg animated:YES];
}

- (void)showWebView:(NSMutableURLRequest *)request {
    WebviewController *web = [[WebviewController alloc] initWithNibName:NSStringFromClass([WebviewController class]) bundle:nil];
    web.mRequest = request;
    [self.navigationController pushViewController:web animated:YES];
}

#pragma mark - Nabigation bar item
- (NSString*)itemRightStandardKey:(NSString*)key{
    return [PHRAppStatus checkCurrentStandardActive] ? kLocalizedString(key) : nil;
}

- (NSString*)itemRightBabyKey:(NSString*)key{
    return [PHRAppStatus checkCurrentBabyActive] ? kLocalizedString(key) : nil;
}

- (void)removeObserve {
    // Do nothing
    // Override me
}

- (void)setIsShowDialog:(BOOL)isShow {
    // Do nothing
}

- (void)refreshAllView {
    
}

@end
