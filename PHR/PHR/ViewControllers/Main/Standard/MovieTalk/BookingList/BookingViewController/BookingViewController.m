//
//  BookingViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/28/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BookingViewController.h"
#import "PHRBookingListViewController.h"
#import "PHRBookingHistoryViewController.h"

@interface BookingViewController () {
  NSMutableArray *_listViewController;
}

@property (nonatomic) int currentControllerIndex;

@end

@implementation BookingViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  [self setupNavigationBarTitle:kLocalizedString(kMyOnlineBooking) iconLeft:@"Icon_Person" iconRight:nil iconMiddle:@"icon_movie_talk_waiting" isDismissView:false colorLeft:PHR_COLOR_MOVIE_TALK_NAV_LEFT colorRight:PHR_COLOR_MOVIE_TALK_NAV_RIGHT];
  _listViewController = [[NSMutableArray alloc] init];
  [self setUpViewControllers];
  [self initTabbarType];
  [_carouselView setType:iCarouselTypeLinear];
  [_carouselView scrollToItemAtIndex:0 animated:NO];
  [_carouselView setPagingEnabled:YES];
  [self.view setClipsToBounds:YES];
  
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.imageBackground];
}

- (void)setUpViewControllers {
  
  PHRBookingListViewController *bookingListVC = [[PHRBookingListViewController alloc]initWithNibName:NSStringFromClass([PHRBookingListViewController class])  bundle:nil];
  bookingListVC.patientClinicAccount = self.patientClinicAccount;
  
  PHRBookingHistoryViewController *bookingHistoryVC = [[PHRBookingHistoryViewController alloc]initWithNibName:NSStringFromClass([PHRBookingHistoryViewController class]) bundle:nil];
  bookingHistoryVC.patientClinicAccount = self.patientClinicAccount;
  
  __weak __typeof__(PHRBookingHistoryViewController) *weakBookingHistory = bookingHistoryVC;
  __weak __typeof__(self) weakSelf = self;
  
  [self.navBarRightIcon setActionBack:^(){
    [weakBookingHistory clearAudioPlayer];
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
  
  [bookingListVC setOpenMovietalkViewController:^(PHRMovieTalkViewController *controller) {
    [weakSelf.navigationController pushViewController:controller animated:YES];
  }];
  [_listViewController addObjectsFromArray:@[bookingListVC,
                                             bookingHistoryVC]];
  _carouselView.dataSource = self;
  _carouselView.delegate = self;
  [_carouselView reloadData];
}

- (void)initTabbarType {
  NSDictionary *typeCourse = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleBookingList) };
  NSDictionary *typeDiseases = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleBookingHistory)};
  NSArray* arr = @[typeCourse,typeDiseases];
  self.tabbarType.topMenuDelegate = self;
  self.tabbarType.backgroundColor = [UIColor clearColor];
  [self.tabbarType setTextFont:[FontUtils aileronSemiBoldWithSize:18.0f]];
  [self.tabbarType calcurateWidth:arr];
}

#pragma mark - TopMenuScrollView delegate
- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView{
  // Do nothing
}


- (void)selectTopMenu:(NSInteger)tagId {
  if (self.carouselView.currentItemIndex != tagId) {
    [self.carouselView setCurrentItemIndex:tagId];
  }
}

#pragma mark - iCarouselDelegate
- (void)carouselCurrentItemIndexDidChange:(iCarousel *)carousel {
  [self.tabbarType setScrollPage:carousel.currentItemIndex];
  self.currentControllerIndex = (int)carousel.currentItemIndex;
}

- (void)carouselWillBeginDragging:(iCarousel *)carousel {
  NSLog(@"Carousel will begin dragging");
}

- (void)carouselDidEndDragging:(iCarousel *)carousel willDecelerate:(BOOL)decelerate {
  NSLog(@"Carousel did end dragging and %@ decelerate", decelerate? @"will": @"won't");
}

- (void)carouselWillBeginDecelerating:(iCarousel *)carousel {
  NSLog(@"Carousel will begin decelerating");
}

- (void)carouselDidEndDecelerating:(iCarousel *)carousel {
  NSLog(@"Carousel did end decelerating");
}

- (void)carouselWillBeginScrollingAnimation:(iCarousel *)carousel {
  NSLog(@"Carousel will begin scrolling");
}

- (void)carouselDidEndScrollingAnimation:(iCarousel *)carousel {
  NSLog(@"Carousel did end scrolling");
}

- (CGFloat)carouselItemWidth:(iCarousel *)carousel {
  return _carouselView.frame.size.width;
}

#pragma mark - iCarouselDataSource
- (NSInteger)numberOfItemsInCarousel:(iCarousel *)carousel {
  return _listViewController.count;
}

- (UIView *)carousel:(iCarousel *)carousel viewForItemAtIndex:(NSInteger)index reusingView:(nullable UIView *)view {
  UIViewController *viewController = _listViewController[index];
  viewController.view.frame = _carouselView.frame;
  return viewController.view;
}

- (CGFloat)carousel:(iCarousel *)carousel valueForOption:(iCarouselOption)option withDefault:(CGFloat)value {
  switch (option) {
    case iCarouselOptionWrap:
      return 1;
    default:
      break;
  }
  
  return value;
}

@end
