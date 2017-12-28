//
//  PHRBookingListViewController.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRBookingListViewController.h"
#import "BookingTableViewCell.h"
#import "UIUtils.h"
#import "PHRClient.h"
#import "BaseNetworking.h"
#import "PHRBookingModel.h"
#import <ReactiveCocoa/ReactiveCocoa.h>
#import "PHRMovieTalkViewController.h"
#import "MovieTalkConnectionManager.h"

@interface PHRBookingListViewController () <UITableViewDelegate, UITableViewDataSource>
@property (nonatomic, weak) IBOutlet UIImageView *imageBackground;
@property (nonatomic, weak) IBOutlet UIView *titleView;
@property (nonatomic, weak) IBOutlet UIView *headerView;
@property (nonatomic, weak) IBOutlet UITableView *tableView;
@property (nonatomic, weak) IBOutlet UILabel *lbHospitalName;
@property (nonatomic, weak) IBOutlet UILabel *lbPatientCode;
@property (nonatomic, weak) IBOutlet UIButton *btnPrevious;
@property (nonatomic, weak) IBOutlet UIButton *btnNext;
@property (nonatomic, weak) IBOutlet UILabel *lbDateTime;
@property (nonatomic, weak) IBOutlet UILabel *lbDay;
@property (nonatomic, weak) IBOutlet UISwipeGestureRecognizer *leftSwipe;
@property (nonatomic, weak) IBOutlet UISwipeGestureRecognizer *rightSwipe;
@property (nonatomic, strong) NSMutableArray *bookingList;
@property (nonatomic, strong) NSMutableDictionary *dictBooking;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *indicatorView;

@property (nonatomic, strong) NSDate *currentDateSession;
@end

@implementation PHRBookingListViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  [self setUpView];
  [self setTodayDateToCurrentDateSession];
  [self setUpTableView];
  [self setUpReactiveAction];
  [self cacheHospitalCode];
  [self getBookingListInfo];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
}

- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  if (!MovieTalkManager.peer.isDisconnected) {
    [MovieTalkManager.peer disconnect];
  }
}

- (void)setUpView {
  //[self setImageToBackgroundStandard:self.imageBackground];
  //  [self setupNavigationBarTitle:kLocalizedString(@"My Booking")
  //                       iconLeft:@"Icon_Person"
  //                      iconRight:@"Icon_Family"
  //                     iconMiddle:@"icon_movie_talk_mybooking"
  //                  isDismissView:false
  //                      colorLeft:PHR_COLOR_MOVIE_TALK_NAV_LEFT
  //                     colorRight:PHR_COLOR_MOVIE_TALK_NAV_RIGHT];
  //  [UIUtils setGradientColorWithLeft:PHR_COLOR_MOVIE_TALK_HEADER_LEFT
  //                           andRight:PHR_COLOR_MOVIE_TALK_HEADER_RIGHT
  //                            forView:_titleView];
  [_lbHospitalName setFont:[UIFont fontWithName:@"Aileron-Regular" size:20.0]];
  [_lbHospitalName setTextColor:RGBCOLOR(255.0, 255.0, 255.0)];
  [_lbPatientCode setFont:[UIFont fontWithName:@"Aileron-Regular" size:17.0]];
  [_lbPatientCode setTextColor:RGBCOLOR(255.0, 255.0, 255.0)];
  NSArray *buttons = @[_btnPrevious, _btnNext];
  for (UIButton *button in buttons) {
    [button.titleLabel setFont:[UIFont fontWithName:@"Aileron-Regular" size:20.0]];
    [button setTitleColor:RGBCOLOR(255.0, 255.0, 255.0)
                 forState:UIControlStateNormal];
    [button setBackgroundImage:[UIImage imageNamed:@"bg_button_normal"]
                      forState:UIControlStateNormal];
    [button setBackgroundImage:[UIImage imageNamed:@"bg_button_selected"]
                      forState:UIControlStateHighlighted];
    [button setBackgroundImage:[UIImage imageNamed:@"bg_button_selected"]
                      forState:UIControlStateSelected];
    if (IS_IOS9) {
      [button setBackgroundImage:[UIImage imageNamed:@"bg_button_selected"]
                        forState:UIControlStateFocused];
    }
  }
  [self setUpHeaderView];
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.indicatorView setHidden:NO];
  } else {
    [self.indicatorView setHidden:YES];
  }
}

- (void)setUpReactiveAction {
  [[_btnNext rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [[BaseNetworking sharedInstance].manager invalidateSessionCancelingTasks:YES];
    [self requestNextDay];
  }];
  [[_btnPrevious rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [[BaseNetworking sharedInstance].manager invalidateSessionCancelingTasks:YES];
    [self requestPreviousDay];
  }];
  [[_leftSwipe rac_gestureSignal] subscribeNext:^(id x) {
    [[BaseNetworking sharedInstance].manager invalidateSessionCancelingTasks:YES];
    [self requestNextDay];
  }];
  [[_rightSwipe rac_gestureSignal] subscribeNext:^(id x) {
    [[BaseNetworking sharedInstance].manager invalidateSessionCancelingTasks:YES];
    [self requestPreviousDay];
  }];
}

- (void)requestPreviousDay {
  [self showOrHideLoading:YES];
  _currentDateSession = [NSUtils getPreviousDateFromDate:_currentDateSession];
  [self updateLabelCurrentDateSessionWith:_currentDateSession];
  [[self bfTaskWithApiKC21With:_currentDateSession] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self handleResponseApiKC21:t];
    return nil;
  }];
}

- (void)requestNextDay {
  [self showOrHideLoading:YES];
  _currentDateSession = [NSUtils getNextDateFromDate:_currentDateSession];
  [self updateLabelCurrentDateSessionWith:_currentDateSession];
  [[self bfTaskWithApiKC21With:_currentDateSession] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self handleResponseApiKC21:t];
    return nil;
  }];
}

- (void)updateLabelCurrentDateSessionWith:(NSDate *)date {
  NSString *dateTimeString = [NSUtils stringFromDate:date withFormat:@"MMM d, yyyy"];
  NSString *dayString = [NSString stringWithFormat:@"%@, ", [NSUtils stringFromDate:date withFormat:@"E"]];
  dayString = [NSUtils checkDateIsToday:date] ? @"Today, " : dayString;
  dispatch_async(dispatch_get_main_queue(), ^{
    _lbDay.text = dayString;
    _lbDateTime.text = dateTimeString;
  });
}

- (void)setTodayDateToCurrentDateSession {
  _currentDateSession = [NSDate date];
  [self updateLabelCurrentDateSessionWith:_currentDateSession];
}

- (void)setUpTableView {
  _dictBooking = [NSMutableDictionary new];
  [_tableView setTableHeaderView:_headerView];
  [_tableView setDelegate:self];
  [_tableView setDataSource:self];
}

- (void)cacheHospitalCode {
  PHRAppStatus.hospitalCode = _patientClinicAccount.model.hospCode;
}

- (void)getBookingListInfo {
  [self showOrHideLoading:YES];
  [[[self bfTaskWithApiKC23] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self handleRequestGetLocateAndHospitalNameWithTask:t];
    return [self bfTaskWithApiKC21With:[NSDate date]];
  }] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    [self handleResponseApiKC21:t];
    return nil;
  }];
}

- (BFTask *)bfTaskWithApiKC23 {
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host_Cms"]];
  NSString *urlApiKC23 = [NSString stringWithFormat:API_KC23,
                          _patientClinicAccount.model.hospCode];
  return [[BaseNetworking sharedInstance] fetchRequest:urlApiKC23
                                                params:nil];
}

- (BFTask *)bfTaskWithApiKC21With:(NSDate *)date {
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host_Mbs"]];
  NSString *currentDateString = [NSUtils stringFromDate:date
                                             withFormat:PHR_TIME_FORMAT_YEAR_MONTH_DAY];
  NSString *urlApiKC21 = [NSString stringWithFormat:API_KC21,
                          currentDateString,
                          _patientClinicAccount.model.hospCode,
                          _patientClinicAccount.model.userName,
                          PHRAppStatus.locate];
  return [[BaseNetworking sharedInstance] fetchRequest:urlApiKC21
                                                params:nil];
}

- (void)handleRequestGetLocateAndHospitalNameWithTask:(BFTask *)t {
  if (t.isCancelled) {
    DLog(@"Cancelled");
  } else if (t.isFaulted) {
    DLog(@"%@", t.error);
  } else {
    NSDictionary *response = (NSDictionary *)t.result;
    DLog(@"%@", response);
    NSDictionary *dictInformation = [response objectForKey:kMT06Data];
    [self cacheLocateAndHospitalName:dictInformation];
    [self setUpHeaderView];
  }
}

- (void)handleResponseApiKC21:(BFTask *)t {
  if (t.isCancelled) {
    DLog(@"Cancelled");
  } else if (t.isFaulted) {
    DLog(@"%@", t.error);
  } else {
    NSDictionary *response = (NSDictionary *)t.result;
    if ([[response objectForKey:@"status"] boolValue]) {
      NSArray *data = [response objectForKey:@"data"];
      NSMutableArray *completed = [NSMutableArray new];
      NSMutableArray *expired = [NSMutableArray new];
      NSMutableArray *upcoming = [NSMutableArray new];
      _dictBooking = nil;
      _dictBooking = [NSMutableDictionary new];
      for (NSDictionary *dict in data) {
        PHRBookingModel *model = [[PHRBookingModel alloc] initWithDictionary:dict];
        model.hospitalName = _patientClinicAccount.model.hospName;
        EXAMINATION_STATUS status = [self getStatusFromModel:model];
        [self setupDataForTableViewWith:model
                                 status:status
                              upComming:upcoming
                                expired:expired
                              completed:completed];
      }
      [_tableView reloadData];
    }
  }
  [self showOrHideLoading:NO];
}

- (void)setupDataForTableViewWith:(PHRBookingModel *)model
                           status:(EXAMINATION_STATUS)status
                        upComming:(NSMutableArray *)upcoming
                          expired:(NSMutableArray *)expired
                        completed:(NSMutableArray *)completed {
  switch (status) {
    case UPCOMING:
      model.displayText = kLocalizedString(@"fe616.label.examination.waiting");
      model.displayOn = @"WAITING";
      model.displayColor = [UIColor greenColor];
      if (![upcoming containsObject:model]) {
        [upcoming addObject:model];
        [_dictBooking setObject:upcoming forKey:[self sectionTitleWith:status]];
      }
      break;
    case EXPIRED:
      model.displayText = kLocalizedString(@"fe616.label.examination.expired");
      model.displayOn = @"EXPIRED";
      model.displayColor = [UIColor grayColor];
      if (![expired containsObject:model]) {
        [expired addObject:model];
        [_dictBooking setObject:expired forKey:[self sectionTitleWith:status]];
      }
      break;
    case COMPLETED:
      model.displayText = kLocalizedString(@"fe616.label.examination.completed");
      model.displayOn = @"COMPLETED";
      model.displayColor = [UIColor blueColor];
      if (![completed containsObject:model]) {
        [completed addObject:model];
        [_dictBooking setObject:completed forKey:[self sectionTitleWith:status]];
      }
      break;
    default:
      break;
  }
}

- (EXAMINATION_STATUS)getStatusFromModel:(PHRBookingModel *)model {
  if ([model.nawonYn isEqualToString:@"E"]) {
    return COMPLETED;
  }
  EXAMINATION_STATUS status;
  NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
  [formatter setDateFormat:@"yyyy/MM/dd HH:mm:ss"];
  NSString *string = [NSString stringWithFormat:@"%@ %@:00", // yyyy/MM/dd HH:mm:00
                      model.examinationDate,
                      [NSUtils timeSeparateWith:model.examinationTime]];
  
  NSDate *bookingDate = [[formatter dateFromString:string] dateByAddingTimeInterval:86400]; // +24h
  NSDate *nextDay = [NSDate date];
  
  switch ([bookingDate compare:nextDay]){
    case NSOrderedAscending:
      status = EXPIRED;
      break;
    case NSOrderedSame:
      status = UPCOMING;
      break;
    case NSOrderedDescending:
      status = UPCOMING;
      break;
  }
  return status;
}

- (NSString *)sectionTitleWith:(EXAMINATION_STATUS)status {
  NSString *title;
  switch (status) {
    case COMPLETED:
      title = [kLocalizedString(@"fe616.label.examination.completed") uppercaseString];
      break;
    case UPCOMING:
      title = [kLocalizedString(@"fe616.label.examination.waiting") uppercaseString];
      break;
    case EXPIRED:
      title = [kLocalizedString(@"fe616.label.examination.expired") uppercaseString];
      break;
    default:
      break;
  }
  return title;
}

- (void)cacheLocateAndHospitalName:(NSDictionary *)dictInformation {
  PHRAppStatus.hospitalName = [self objectOrNilForKey:kKC23HospitalName fromDictionary:dictInformation];
  PHRAppStatus.locate = [self objectOrNilForKey:kKC23Locale fromDictionary:dictInformation];
}

- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict {
  id object = [dict objectForKey:aKey];
  return [object isEqual:[NSNull null]] ? @"" : object;
}

- (void)setUpHeaderView {
  _lbHospitalName.text = _patientClinicAccount.model.hospName;
  _lbPatientCode.text = _patientClinicAccount.model.userName;
}

#pragma mark - UITableViewDelegate
- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section {
  return 40;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
  UIView *view = [[UIView alloc] initWithFrame:CGRectMake(0, 0, tableView.frame.size.width, 40)];
  CGRect viewRect = view.frame;
  UILabel *lblTitle = [[UILabel alloc] init];
  CGRect lblTitleRect = lblTitle.frame;
  lblTitleRect.origin.x = 20;
  lblTitleRect.origin.y = 0;
  lblTitleRect.size.width = viewRect.size.width - lblTitleRect.origin.x;
  lblTitleRect.size.height = viewRect.size.height;
  lblTitle.frame = lblTitleRect;
  if (_dictBooking.allKeys != nil && _dictBooking.allKeys.count > 0) {
    [lblTitle setText:_dictBooking.allKeys[section] ? _dictBooking.allKeys[section] : @""];
  }
  [lblTitle setTextColor:[UIColor darkGrayColor]];
  [view setBackgroundColor:[UIColor lightGrayColor]];
  [view addSubview:lblTitle];
  UIImageView *bottomImageView = [[UIImageView alloc] init];
  CGRect bottomImageViewRect = bottomImageView.frame;
  bottomImageViewRect.origin.x = 0;
  bottomImageViewRect.size.height = 1;
  bottomImageViewRect.origin.y = viewRect.size.height - bottomImageViewRect.size.height;
  bottomImageViewRect.size.width = viewRect.size.width;
  bottomImageView.frame = bottomImageViewRect;
  bottomImageView.image = [UIImage imageNamed:@"bg_tableview_separator_line"];
  [view addSubview:bottomImageView];
  return view;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return [BookingTableViewCell cellHeight];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  [tableView deselectRowAtIndexPath:indexPath animated:YES];
  NSString *sectionTitle = _dictBooking.allKeys[indexPath.section];
  NSArray *arrayBooking = [_dictBooking objectForKey:sectionTitle];
  PHRBookingModel *model = arrayBooking[indexPath.row];
  if (![model.displayText isEqualToString:kLocalizedString(@"fe616.label.examination.waiting")]) {
    return;
  }
  PHRMovieTalkViewController *controller = [[PHRMovieTalkViewController alloc] initWithNibName:NSStringFromClass([PHRMovieTalkViewController class]) bundle:nil];
  controller.model = model;
  self.openMovietalkViewController(controller);
  //[self presentViewController:controller animated:YES completion:nil];
}

#pragma mark - UITableViewDataSource
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return _dictBooking.allKeys.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  NSString *sectionTitle = _dictBooking.allKeys[section];
  NSArray *arrayBooking = [_dictBooking objectForKey:sectionTitle];
  return arrayBooking.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  BookingTableViewCell *cell = (BookingTableViewCell *)[tableView dequeueReusableCellWithIdentifier:@"BookingTableViewCell"];
  if (!cell) {
    cell = (BookingTableViewCell *)[[[NSBundle mainBundle] loadNibNamed:@"BookingTableViewCell"
                                                                  owner:self
                                                                options:nil] objectAtIndex:0];
  }
  NSString *sectionTitle = _dictBooking.allKeys[indexPath.section];
  NSArray *arrayBooking = [_dictBooking objectForKey:sectionTitle];
  [cell bindViewModel:arrayBooking[indexPath.row]];
  return cell;
}

@end