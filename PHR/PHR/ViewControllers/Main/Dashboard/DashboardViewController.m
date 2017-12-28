//
//  DashboardViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "DashboardViewController.h"
#import "StandardHomeViewController.h"
#import "ChildrenHomeViewController.h"
#import "ProfileChildrenViewController.h"
#import "FamilyListViewController.h"
#import "CETurnAnimationController.h"
#import "CEHorizontalSwipeInteractionController.h"
#import "ChildrenDashboardViewController.h"

static const CGFloat kTabBarHeight = 0; // 55

@interface DashboardViewController ()

@property (nonatomic, strong) UINavigationController *standardNav;
@property (nonatomic, strong) UINavigationController *babyNav;

@end

@implementation DashboardViewController{
    CETurnAnimationController *_animationController;
    CEHorizontalSwipeInteractionController *_swipeInteractionController;
    ChildrenDashboardViewController *childrenDashBoardVC;
}

- (id)init {
    if (self = [super init]) {
        self.delegate = self;
        // create the interaction / animation controllers
        _swipeInteractionController = [CEHorizontalSwipeInteractionController new];
        _animationController = [CETurnAnimationController new];
        _animationController.duration = 0.4;
        
        // observe changes in the currently presented view controller
        [self addObserver:self
               forKeyPath:@"selectedViewController"
                  options:NSKeyValueObservingOptionNew
                  context:nil];
    }
    return self;
}

- (void)dealloc
{
    DLog(@"DEALLOC CELL");
    [[NSNotificationCenter defaultCenter] removeObserver:self];
    [self removeObserver:self forKeyPath:@"selectedViewController"];
    [childrenDashBoardVC removeAllObserve];
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.hidesBottomBarWhenPushed = YES;
    
    // Create tabbar
    
    PHRAppStatus.type = PHRGroupTypeStandard;
    // Navigation bar standard
    
    StandardHomeViewController *standardController = [[StandardHomeViewController alloc] initWithNibName:NSStringFromClass([StandardHomeViewController class]) bundle:nil];
    _standardNav = [[UINavigationController alloc] initWithRootViewController:standardController];
    
    _standardNav.navigationBarHidden = YES;    
    
    /*
    ChildrenHomeViewController *babyController = [[ChildrenHomeViewController alloc] initWithNibName:NSStringFromClass([ChildrenHomeViewController class]) bundle:nil];
    _babyNav = [[UINavigationController alloc] initWithRootViewController:babyController];
    _babyNav.navigationBarHidden = YES;
    */
    childrenDashBoardVC = [[ChildrenDashboardViewController alloc] initWithNibName:NSStringFromClass([ChildrenDashboardViewController class]) bundle:nil];
    _babyNav = [[UINavigationController alloc] initWithRootViewController:childrenDashBoardVC];
    _babyNav.navigationBarHidden = YES;
    
    
    self.viewControllers = [[NSArray alloc] initWithObjects:_standardNav, _babyNav, nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(switchTab:) name:kNotifyCloseMenuLeft object:nil];
    
    // Check nav bar standard enable
    if (PHRAppStatus.currentStandard ==  nil) {
        // disable tabbar
//        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(@"Choose Profile Dialog")];
        
        // Move to profile list
        FamilyListViewController *family = [[FamilyListViewController alloc] initWithNibName:NSStringFromClass([FamilyListViewController class]) bundle:nil];
        family.type = PHRGroupTypeStandard;
        family.isShowHelpImage = YES;
        [_standardNav pushViewController:family animated:NO];
    }
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleChangedTabbarIndex:) name:kNotifyDashboardChangeTabbarIndex object:nil];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
    if (PHRAppStatus.currentStandard && !_standardNav.tabBarItem.enabled){
        [_standardNav.tabBarItem setEnabled:YES];
        [_babyNav.tabBarItem setEnabled:YES];

    }
    if (PHRAppStatus.currentBaby && !_babyNav.tabBarItem.enabled){
        [_babyNav.tabBarItem setEnabled:YES];
    }
}

- (void)handleChangedTabbarIndex:(NSNotification*)notification{
    int index = 0;
    if(notification.object){
        index = [notification.object intValue];
    }
    self.selectedIndex = index;
}

- (void)viewWillLayoutSubviews {
    [super viewWillLayoutSubviews];
    CGRect tabFrame = self.tabBar.frame;
    tabFrame.size.height = kTabBarHeight;
    tabFrame.origin.y = self.view.frame.size.height - kTabBarHeight;
    self.tabBar.frame = tabFrame;
    // Tabbar appearance
    [self.tabBar setBackgroundImage:[UIUtils imageFromColor:[UIColor whiteColor] forSize:CGSizeMake(SCREEN_WIDTH, kTabBarHeight) withCornerRadius:0]];
    [self updateTabbarIndicatorColorSelection:self.tabBar.selectedItem.tag];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) switchTab:(NSNotification*) notify {
    NSString* content = (NSString*) notify.object;
    if ([content isEqualToString:@"STANDARD"]) {
        [self setSelectedIndex:0];
        PHRAppStatus.isLocalStandard = YES;
        PHRAppStatus.isLocalBaby = NO;
    } else {
        [self setSelectedIndex:1];
        PHRAppStatus.isLocalBaby = YES;
        PHRAppStatus.isLocalStandard = NO;
    }
}

- (void)tabBar:(UITabBar *)tabBar didSelectItem:(UITabBarItem *)item {
    if ([item.title isEqualToString:kLocalizedString(kStandardTitle)]) {
        PHRAppStatus.type = PHRGroupTypeStandard;
        if (PHRAppStatus.currentBaby ==  nil) {
            [_babyNav.tabBarItem setEnabled:YES];
        }
    }
    else {
        PHRAppStatus.type = PHRGroupTypeBaby;
        if (!PHRAppStatus.arrayBabyProfile || PHRAppStatus.arrayBabyProfile.count <= 0) {
            ProfileChildrenViewController *controller = [[ProfileChildrenViewController alloc] initWithNibName:NSStringFromClass([ProfileChildrenViewController class]) bundle:nil];
            controller.type = PHRGroupTypeBaby;
            [_babyNav pushViewController:controller animated:NO];
        }
        else if (PHRAppStatus.currentBaby ==  nil) {
            // disable tabbar
            [_babyNav.tabBarItem setEnabled:NO];
            
            
            // Move to profile list
            FamilyListViewController *family = [[FamilyListViewController alloc] initWithNibName:NSStringFromClass([FamilyListViewController class]) bundle:nil];
            family.type = PHRGroupTypeBaby;
            [_babyNav pushViewController:family animated:NO];
        }
    }
    [self updateTabbarIndicatorColorSelection:item.tag];
}

- (void)updateTabbarIndicatorColorSelection:(NSInteger)index {
    UIColor *color = index == 0 ? PHR_COLOR_CYAN : PHR_COLOR_PINK;
    [self.tabBar setSelectionIndicatorImage:[UIUtils imageFromColor:color forSize:CGSizeMake(SCREEN_WIDTH/2, kTabBarHeight) withCornerRadius:0]];
}

#pragma mark - Tabbar Transition Animation
- (void)observeValueForKeyPath:(NSString *)keyPath ofObject:(id)object
                        change:(NSDictionary *)change
                       context:(void *)context
{
    if ([keyPath isEqualToString:@"selectedViewController"] )
    {
        // wire the interaction controller to the view controller
        [_swipeInteractionController wireToViewController:self.selectedViewController
                                             forOperation:CEInteractionOperationTab];
    }
}



- (id <UIViewControllerAnimatedTransitioning>)tabBarController:(UITabBarController *)tabBarController
            animationControllerForTransitionFromViewController:(UIViewController *)fromVC
                                              toViewController:(UIViewController *)toVC
{
    NSUInteger fromVCIndex = [tabBarController.viewControllers indexOfObject:fromVC];
    NSUInteger toVCIndex = [tabBarController.viewControllers indexOfObject:toVC];
    _animationController.reverse = fromVCIndex < toVCIndex;
    return _animationController;
}

-(id<UIViewControllerInteractiveTransitioning>)tabBarController:(UITabBarController *)tabBarController interactionControllerForAnimationController:(id<UIViewControllerAnimatedTransitioning>)animationController
{
    return _swipeInteractionController.interactionInProgress ? _swipeInteractionController : nil;
}

@end
