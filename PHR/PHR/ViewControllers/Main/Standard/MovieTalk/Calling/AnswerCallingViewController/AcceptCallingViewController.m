//
//  AcceptCallingViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AcceptCallingViewController.h"
#import "PHRMovieTalkViewController.h"
#import "SampleQueueId.h"

@interface AcceptCallingViewController ()

@property (nonatomic, strong) STKAudioPlayer* audioPlayer;

@end

@implementation AcceptCallingViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  [self setupAudioPlayer];
  self.viewReject.layer.cornerRadius = self.viewReject.frame.size.width / 2;
  self.viewAccept.layer.cornerRadius = self.viewAccept.frame.size.width / 2;
  NSString *strCallFrom = [NSString stringWithFormat:kLocalizedString(kReceiveCallingFrom), [self.dictUserInfo objectForKey:@"doctor_name"], [self.dictUserInfo objectForKey:@"hospital_name"]];
  self.labelCallFrom.text = strCallFrom;
  [self.view setBackgroundColor:[UIColor colorWithRed:9./255. green:133./255. blue:237./255. alpha:1]];
  [self createAVPlayer];
}


- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];
}

- (void)viewDidDisappear:(BOOL)animated {
  [super viewDidDisappear:animated];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (IBAction)onClickBtnDecline:(id)sender {
  [self clearAudioPlayer];
  [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)onClickBtnAcceptCalling:(id)sender {
  [self clearAudioPlayer];
  PHRBookingModel *model = [[PHRBookingModel alloc] init];
  //  model.doctorCode = @"123";
  //  model.doctorName = @"123";
  //  model.patientCode = @"123";
  //  model.hospitalName = @"123";
  model.doctorCode = [self.dictUserInfo objectForKey:@"doctor_code"];
  model.doctorName = [self.dictUserInfo objectForKey:@"doctor_name"];
  model.patientCode = [self.dictUserInfo objectForKey:@"patient_code"];
  model.hospitalName = [self.dictUserInfo objectForKey:@"hospital_name"];
  
  PHRMovieTalkViewController *controller = [[PHRMovieTalkViewController alloc] initWithNibName:NSStringFromClass([PHRMovieTalkViewController class]) bundle:nil];
  controller.model = model;
  controller.callID = [self.dictUserInfo objectForKey:@"calling_id"];
  //  controller.callID = @"ey92";
  [self.navigationController pushViewController:controller animated:YES];
}

- (void)setupAudioPlayer {
  NSError* error;
  
  [[AVAudioSession sharedInstance] setCategory:AVAudioSessionCategoryPlayback error:&error];
  [[AVAudioSession sharedInstance] setActive:YES error:&error];
  
  Float32 bufferLength = 0.1;
  AVAudioSession *session = [AVAudioSession sharedInstance];
  
  NSError *setCategoryError = nil;
  [session setPreferredIOBufferDuration:bufferLength error:&setCategoryError];
  
  self.audioPlayer = [[STKAudioPlayer alloc] initWithOptions:(STKAudioPlayerOptions){ .flushQueueOnSeek = YES, .enableVolumeMixer = NO, .equalizerBandFrequencies = {50, 100, 200, 400, 800, 1600, 2600, 16000} }];
  self.audioPlayer.meteringEnabled = YES;
  self.audioPlayer.volume = 1;
  self.audioPlayer.delegate = self;
}

- (void)createAVPlayer {
  
  NSString* path = [[NSBundle mainBundle] pathForResource:@"calling_sound" ofType:@"mp3"];
  NSURL* url = [NSURL fileURLWithPath:path];
  
  STKDataSource* dataSource = [STKAudioPlayer dataSourceFromURL:url];
  [self.audioPlayer setDataSource:dataSource withQueueItemId:[[SampleQueueId alloc] initWithUrl:url andCount:0]];
}

-(void)audioPlayer:(STKAudioPlayer*)audioPlayer didFinishBufferingSourceWithQueueItemId:(NSObject*)queueItemId {
  // This queues on the currently playing track to be buffered and played immediately after (gapless)
  
  SampleQueueId* queueId = (SampleQueueId*)queueItemId;
  [self.audioPlayer queueDataSource:[STKAudioPlayer dataSourceFromURL:queueId.url] withQueueItemId:[[SampleQueueId alloc] initWithUrl:queueId.url andCount:queueId.count + 1]];
  
}

- (void)audioPlayer:(STKAudioPlayer*)audioPlayer stateChanged:(STKAudioPlayerState)state previousState:(STKAudioPlayerState)previousState {
  // do nothing
}

- (void)audioPlayer:(STKAudioPlayer*)audioPlayer unexpectedError:(STKAudioPlayerErrorCode)errorCode {
  // do nothing
}

- (void)audioPlayer:(STKAudioPlayer*)audioPlayer didStartPlayingQueueItemId:(NSObject*)queueItemId {
  // do nothing
}

- (void)audioPlayer:(STKAudioPlayer*)audioPlayer didFinishPlayingQueueItemId:(nonnull NSObject *)queueItemId withReason:(STKAudioPlayerStopReason)stopReason andProgress:(double)progress andDuration:(double)duration {
  // do nothing
}

- (void)dealloc {
  [self clearAudioPlayer];
}

- (void)clearAudioPlayer {
  [self.audioPlayer stop];
  [self.audioPlayer dispose];
  [self.audioPlayer clearQueue];
  self.audioPlayer = nil;
}

@end
