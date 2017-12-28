//
//  PHRMovieTalkViewController.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRMovieTalkViewController.h"
#import <SkyWay/SKWPeer.h>
#import <ReactiveCocoa/ReactiveCocoa.h>
#import "BaseNetworking.h"
#import "AudioManager.h"
#import "AcceptCallingViewController.h"

static NSString *const kHost = @"mis.karte.clinic";
//@"117.6.172.190";
static NSInteger const kPort = 443;

@interface PHRMovieTalkViewController () <UIAlertViewDelegate>
@property (nonatomic, weak) IBOutlet UIImageView *imageBackground;
@property (nonatomic, weak) IBOutlet SKWVideo *viewLocal;
@property (nonatomic, weak) IBOutlet SKWVideo *viewRemote;
@property (nonatomic, weak) IBOutlet UIButton *btnEndCall;
@property (nonatomic, weak) IBOutlet UIButton *btnChat;
@property (nonatomic, weak) IBOutlet UIButton *btnVideo;
@property (nonatomic, weak) IBOutlet UIView *bottomView;
@property (weak, nonatomic) IBOutlet UIView *superViewChat;
@property (nonatomic, weak) IBOutlet UILabel *lbHospitalName;
@property (nonatomic, weak) IBOutlet UILabel *lbPatientCode;
@property (weak, nonatomic) IBOutlet UILabel *labelDoctorName;
@property (weak, nonatomic) IBOutlet UILabel *labelOnline;
@property (weak, nonatomic) IBOutlet UIButton *btnBackToChat;
@property (weak, nonatomic) IBOutlet UIView *viewChat;
@property (strong, nonatomic) NSString *strOwnID;

@end

@implementation PHRMovieTalkViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  [self setUpView];
  [self removeAcceptViewControllerIfNeeded];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  
  [self setUpReactiveAction];
}

- (void)removeAcceptViewControllerIfNeeded {
  
  NSArray *arrViewController = self.navigationController.viewControllers;
  for (UIViewController *controller in arrViewController) {
    if ([controller isKindOfClass:[AcceptCallingViewController class]]) {
      [controller removeFromParentViewController];
    }
  }
}

- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];
  NSString *mediaType = AVMediaTypeVideo;
  AVAuthorizationStatus authStatus = [AVCaptureDevice authorizationStatusForMediaType:mediaType];
  if(authStatus == AVAuthorizationStatusAuthorized) {
    // do your logic
    [self setUpSkyWay];
  } else if(authStatus == AVAuthorizationStatusDenied){
    // denied
    [NSUtils showMessage:kLocalizedString(kPleaseAllowCameraMovieTalk) withTitle:kLocalizedString(kAlert) andDelegate:self];
  } else if(authStatus == AVAuthorizationStatusRestricted){
    // restricted, normally won't happen
  } else if(authStatus == AVAuthorizationStatusNotDetermined){
    // not determined?!
    [AVCaptureDevice requestAccessForMediaType:mediaType completionHandler:^(BOOL granted) {
      if(granted){
      } else {
      }
    }];
  } else {
    // impossible, unknown authorization status
  }
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  if (MovieTalkManager.mediaConnection) {
    [self clearMediaCallbacks:MovieTalkManager.mediaConnection];
  }
  if (MovieTalkManager.msLocal) {
    [MovieTalkManager.msLocal close];
    MovieTalkManager.msLocal = nil;
  }
  if (MovieTalkManager.peer) {
    [self clearCallbacks:MovieTalkManager.peer];
  }
  [SKWNavigator terminate];
  if (MovieTalkManager.peer) {
    [MovieTalkManager.peer destroy];
  }
  MovieTalkManager.bConnected = NO;
  [[AudioManager sharedInstance] setEnableAudioOutputSpeaker:NO];
  if (!self.callID || self.callID.isEmpty) {
    [self putIdToCall:@""];
  }
}

- (void)viewDidLayoutSubviews {
  [super viewDidLayoutSubviews];
  
  self.chatVC.view.frame = CGRectMake(0, 0, [[UIScreen mainScreen] bounds].size.width, self.viewChat.frame.size.height);
  [self addChildViewController:self.chatVC];
  [self.viewChat addSubview:self.chatVC.view];
  [self.chatVC didMoveToParentViewController:self];
}

- (void)dealloc {
  [self clearAllPear];
}

- (void)setUpView {
  [self setImageToBackgroundStandard:self.imageBackground];
  [self setupNavigationBarTitle:kLocalizedString(@"Movie Talk")
                       iconLeft:@"Icon_Person"
                      iconRight:nil
                     iconMiddle:@"icon_movie_talk_waiting"
                  isDismissView:false
                      colorLeft:PHR_COLOR_MOVIE_TALK_NAV_LEFT
                     colorRight:PHR_COLOR_MOVIE_TALK_NAV_RIGHT];
  
  __weak __typeof__(self) weakSelf = self;
  
  [self.navBarRightIcon setActionBack:^(){
    [weakSelf clearAllPear];
    [weakSelf.navigationController popViewControllerAnimated:YES];
  }];
  
  //
  self.chatVC = [ChatViewController messagesViewController];
  self.superViewChat.hidden = YES;
  self.labelOnline.font = [FontUtils aileronBoldWithSize:13];
  if (self.model) {
    self.labelDoctorName.font = [FontUtils aileronBoldWithSize:15];
    self.labelDoctorName.text = self.model.doctorName;
    self.labelDoctorName.textColor = [UIColor colorWithRed:79./255. green:79./255. blue:79./255. alpha:1];
  }
  MovieTalkManager.dataConnection ? [self updateLabelOnline:YES] : [self updateLabelOnline:NO];
  
  [_lbHospitalName setFont:[FontUtils aileronRegularWithSize:15]];
  [_lbHospitalName setTextColor:[UIColor blackColor]];
  [_lbPatientCode setFont:[FontUtils aileronRegularWithSize:13]];
  [_lbPatientCode setTextColor:[UIColor blackColor]];
  _lbHospitalName.text = self.model.hospitalName;
  _lbPatientCode.text = self.model.patientCode;
}

- (void)setUpReactiveAction {
  [[_btnVideo rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [_btnVideo setSelected:!_btnVideo.isSelected];
    [MovieTalkManager.msLocal setEnableVideoTrack:0 enable:!_btnVideo.isSelected];
  }];
  [[_btnEndCall rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [[AudioManager sharedInstance] setEnableAudioOutputSpeaker:NO];
    [self.navigationController popViewControllerAnimated:YES];
  }];
  [[_btnChat rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [self.superViewChat setHidden:NO];
    [self.viewRemote setHidden:YES];
    [self.view endEditing:YES];
  }];
  [[_btnBackToChat rac_signalForControlEvents:UIControlEventTouchUpInside] subscribeNext:^(id x) {
    [self.superViewChat setHidden:YES];
    [self.viewRemote setHidden:NO];
    [self.view endEditing:YES];
  }];
}

#pragma mark - UIAlertView Delegate
- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex{
  if (buttonIndex == 1) {
    [[UIApplication sharedApplication] openURL:[NSURL URLWithString:UIApplicationOpenSettingsURLString]];
  }
}

#pragma mark - Show/Hide Camera
- (void)showLocalCamera {
  [self createLocalCamera];
  [_viewLocal addSrc:MovieTalkManager.msLocal track:0];
}

- (void)createLocalCamera {
  MovieTalkManager.msLocal = [SKWNavigator getUserMedia:[self setUpMediaConstraints]];
}

#pragma mark - SkyWay
- (void)setUpSkyWay {
  MovieTalkManager.peer = [[SKWPeer alloc] initWithId:nil options:[self setUpSkyWayOption]];
  [self setCallbacks:MovieTalkManager.peer];
  [SKWNavigator initialize:MovieTalkManager.peer];
  [_viewRemote setTag:VIDEO_CHAT_TAG_REMOTE_VIDEO];
  [_viewRemote setUserInteractionEnabled:NO];
  [_viewLocal setTag:VIDEO_CHAT_TAG_LOCAL_VIDEO];
  [self showLocalCamera];
}

- (SKWPeerOption *)setUpSkyWayOption {
  
  //  //Replace Here
  //  SKWPeerOption *option = [[SKWPeerOption alloc] init];
  //  option.host = @"10.1.20.34";
  //  option.port = 9000;
  //  option.type = SKW_PEER_TYPE_PEERJS;
  //  option.path = @"";
  //
  //  option.secure = NO;
  //  option.debug = SKW_DEBUG_LEVEL_ALL_LOGS;
  //  return option;
  
  
  SKWPeerOption *option = [[SKWPeerOption alloc] init];
  option.host = kHost;
  option.port = kPort;
  option.type = SKW_PEER_TYPE_PEERJS;
  option.path = @"/peerjs";
  option.secure = YES;
  option.debug = SKW_DEBUG_LEVEL_ALL_LOGS;
  return option;
}

- (void)updateLabelOnline:(BOOL)isOnline {
  if (isOnline) {
    self.labelOnline.textColor = [UIColor colorWithRed:73./255. green:162./255. blue:37./255. alpha:1];
    self.labelOnline.text = kLocalizedString(kOnline);
  } else {
    self.labelOnline.textColor = PHR_COLOR_GRAY;
    self.labelOnline.text = kLocalizedString(kOffline);
  }
}

- (SKWMediaConstraints *)setUpMediaConstraints {
  SKWMediaConstraints *constraints = [[SKWMediaConstraints alloc] init];
  constraints.cameraPosition = SKW_CAMERA_POSITION_FRONT;
  constraints.cameraMode = SKW_CAMERA_MODE_ADJUSTABLE;
  return constraints;
}

#pragma mark - Callbacks
- (void)setCallbacks:(SKWPeer *)peer {
  if (!peer) {
    return;
  }
  // Event/Open
  [peer on:SKW_PEER_EVENT_OPEN callback:^(NSObject* obj) {
    if ([obj isKindOfClass:[NSString class]]) {
      NSString *_strOwnId = (NSString *)obj;
      DLog(@"____ ID: %@", _strOwnId);
      if (self.callID && self.callID != (id)[NSNull null] && !self.callID.isEmpty) {
        [self callToDoctor];
        [self connectDataStream];
      } else {
        [self putIdToCall:_strOwnId];
      }
      
    }
  }];
  // Event/Call
  [peer on:SKW_PEER_EVENT_CALL callback:^(NSObject* obj) {
    if ([obj isKindOfClass:[SKWMediaConnection class]]) {
      MovieTalkManager.mediaConnection = (SKWMediaConnection *)obj;
      [self setMediaCallbacks:MovieTalkManager.mediaConnection];
      [MovieTalkManager.mediaConnection answer:MovieTalkManager.msLocal];
    }
  }];
  
  // Connection
  [peer on:SKW_PEER_EVENT_CONNECTION callback:^(NSObject* obj) {
    if ([obj isKindOfClass:[SKWDataConnection class]]) {
      MovieTalkManager.dataConnection = (SKWDataConnection *)obj;
      [self setDataCallbacks:MovieTalkManager.dataConnection];
      [self updateLabelOnline:YES];
    }
  }];
  
  // Event/Close
  [peer on:SKW_PEER_EVENT_CLOSE callback:^(NSObject* obj) {
    DLog(@"SKW_PEER_EVENT_CLOSE: %@", obj);
    [self closedMedia];
    if (!self.callID || self.callID.isEmpty) {
      [self putIdToCall:@""];
    }
    
  }];
  // Event/Disconnected
  [peer on:SKW_PEER_EVENT_DISCONNECTED callback:^(NSObject* obj) {
    DLog(@"SKW_PEER_EVENT_DISCONNECTED: %@", obj);
  }];
  // Event/Error
  [peer on:SKW_PEER_EVENT_ERROR callback:^(NSObject* obj) {
    DLog(@"SKW_PEER_EVENT_ERROR: %@", obj);
  }];
}

- (void)setMediaCallbacks:(SKWMediaConnection *)media {
  if (media == nil) {
    return;
  }
  // MediaEvent/Stream
  __weak typeof(self) weakSelf = self;
  [media on:SKW_MEDIACONNECTION_EVENT_STREAM callback:^(NSObject* obj) {
    DLog(@"SKW_MEDIACONNECTION_EVENT_STREAM");
    __strong typeof(weakSelf) strongSelf = weakSelf;
    // Add Stream;
    if ([obj isKindOfClass:[SKWMediaStream class]]) {
      SKWMediaStream* stream = (SKWMediaStream *)obj;
      [strongSelf setRemoteView:stream];
    }
  }];
  // MediaEvent/Close
  [media on:SKW_MEDIACONNECTION_EVENT_CLOSE callback:^(NSObject* obj) {
    DLog(@"SKW_MEDIACONNECTION_EVENT_CLOSE: %@", obj);
    [self closedMedia];
  }];
  // MediaEvent/Error
  [media on:SKW_MEDIACONNECTION_EVENT_ERROR callback:^(NSObject* obj) {
    DLog(@"SKW_MEDIACONNECTION_EVENT_ERROR: %@", obj);
  }];
}

#pragma mark - Data Callbacks
- (void)setDataCallbacks:(SKWDataConnection *)data {
  if (data == nil) {
    return;
  }
  [data on:SKW_DATACONNECTION_EVENT_OPEN callback:^(NSObject* obj) {
    DLog(@"SKW_DATACONNECTION_EVENT_OPEN");
    dispatch_async(dispatch_get_main_queue(), ^ {
      [self updateLabelOnline:YES];
    });
  }];
  
  //receive data
  [data on:SKW_DATACONNECTION_EVENT_DATA callback:^(NSObject* obj) {
    DLog(@"SKW_DATACONNECTION_EVENT_DATA");
    NSString* strData = nil;
    if ([obj isKindOfClass:[NSString class]]) {
      strData = (NSString *)obj;
      [self.chatVC handleIncomingMessage:strData];
    }
  }];
  
  [data on:SKW_DATACONNECTION_EVENT_CLOSE callback:^(NSObject* obj) {
    DLog(@"SKW_DATACONNECTION_EVENT_CLOSE");
    dispatch_async(dispatch_get_main_queue(), ^ {
      [self updateLabelOnline:NO];
    });
    [self closeConnection];
  }];
  
  [data on:SKW_DATACONNECTION_EVENT_ERROR callback:^(NSObject* obj) {
    DLog(@"SKW_DATACONNECTION_EVENT_ERROR");
    
  }];
}

- (void)clearCallbacks:(SKWPeer *)peer {
  if (!peer) {
    return;
  }
  [peer on:SKW_PEER_EVENT_OPEN callback:nil];
  [peer on:SKW_PEER_EVENT_CONNECTION callback:nil];
  [peer on:SKW_PEER_EVENT_CALL callback:nil];
  [peer on:SKW_PEER_EVENT_CLOSE callback:nil];
  [peer on:SKW_PEER_EVENT_DISCONNECTED callback:nil];
  [peer on:SKW_PEER_EVENT_ERROR callback:nil];
}

- (void)clearMediaCallbacks:(SKWMediaConnection *)media {
  if (!media) {
    return;
  }
  [media on:SKW_MEDIACONNECTION_EVENT_STREAM callback:nil];
  [media on:SKW_MEDIACONNECTION_EVENT_CLOSE callback:nil];
  [media on:SKW_MEDIACONNECTION_EVENT_ERROR callback:nil];
}

- (void)clearConnectionCallbacks:(SKWDataConnection *)data {
  if (!data) {
    return;
  }
  [data on:SKW_DATACONNECTION_EVENT_OPEN callback:nil];
  [data on:SKW_DATACONNECTION_EVENT_DATA callback:nil];
  [data on:SKW_DATACONNECTION_EVENT_CLOSE callback:nil];
  [data on:SKW_DATACONNECTION_EVENT_ERROR callback:nil];
}


- (void)setRemoteView:(SKWMediaStream *)stream {
  if (MovieTalkManager.bConnected) {
    return;
  }
  MovieTalkManager.bConnected = YES;
  MovieTalkManager.msRemote = stream;
  dispatch_async(dispatch_get_main_queue(), ^{
    [_viewRemote setUserInteractionEnabled:YES];
    [_viewRemote addSrc:MovieTalkManager.msRemote track:0];
    [self.view bringSubviewToFront:self.viewRemote];
    [[AudioManager sharedInstance] setEnableAudioOutputSpeaker:YES];
  });
}

- (void)closeConnection {
  if (!MovieTalkManager.dataConnection)
    return;
  [self clearConnectionCallbacks:MovieTalkManager.dataConnection];
  [MovieTalkManager.dataConnection close];
  MovieTalkManager.dataConnection = nil;
}

- (void)unsetRemoteView {
  if (!MovieTalkManager.bConnected) {
    return;
  }
  MovieTalkManager.bConnected = NO;
  dispatch_async(dispatch_get_main_queue(), ^{
    if (MovieTalkManager.msRemote) {
      [_viewRemote removeSrc:MovieTalkManager.msRemote track:0];
      [MovieTalkManager.msRemote close];
      MovieTalkManager.msRemote = nil;
    }
  });
}

- (void)closedMedia {
  [self unsetRemoteView];
  [self clearMediaCallbacks:MovieTalkManager.mediaConnection];
  [MovieTalkManager.mediaConnection close];
  MovieTalkManager.mediaConnection = nil;
}

#pragma mark - Networking
- (void)putIdToCall:(NSString *)idCall {
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host_Mbs"]];
  NSString *urlApiMT03 = [NSString stringWithFormat:API_MT03];
  NSDictionary *params = @{@"reservation_code": _model.reservationCode ? _model.reservationCode : @"",
                           @"hospital_code": PHRAppStatus.hospitalCode,
                           @"mt_calling_id": idCall
                           };
  [[[BaseNetworking sharedInstance] putRequest:urlApiMT03 params:params] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    if (t.isCancelled) {
      DLog(@"Cancelled");
    } else if (t.isFaulted) {
      DLog(@"Faulted");
      DLog(@"%@", t.error);
    } else {
      DLog(@"%@", t.result);
    }
    return nil;
  }];
}

#pragma mark call
- (void)callToDoctor {
  if (!MovieTalkManager.peer || !self.callID || self.callID.isEmpty) {
    return;
  }
  MovieTalkManager.mediaConnection = [MovieTalkManager.peer callWithId:self.callID stream:MovieTalkManager.msLocal];
  [self setMediaCallbacks:MovieTalkManager.mediaConnection];
}

- (void)connectDataStream {
  SKWConnectOption* option = [[SKWConnectOption alloc] init];
  option.label = @"chat";
  option.metadata = @"{'message': 'hi'}";
  option.serialization = SKW_SERIALIZATION_BINARY;
  option.reliable = YES;
  MovieTalkManager.dataConnection = [MovieTalkManager.peer connectWithId:self.callID options:option];
  [self setDataCallbacks:MovieTalkManager.dataConnection];
}

- (void)clearAllPear {
  MovieTalkManager.msLocal = nil;
  MovieTalkManager.msRemote = nil;
  MovieTalkManager.mediaConnection = nil;
  MovieTalkManager.dataConnection = nil;
  MovieTalkManager.peer = nil;
}

@end
