//
//  PHRBookingHistoryViewController.m
//  PHR
//
//  Created by Dao Xuan Tu on 11/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRBookingHistoryViewController.h"
#import "BaseNetworking.h"
#import "STKAudioPlayer.h"

#define TABLE_CELL_HEIGHT 60


@interface PHRBookingHistoryViewController ()<UITableViewDelegate, UITableViewDataSource>
@property (weak, nonatomic) IBOutlet UIButton *btnAction;
@property (weak, nonatomic) IBOutlet UIButton *btnNext;
@property (weak, nonatomic) IBOutlet UIButton *btnPrevious;

@property (weak, nonatomic) IBOutlet UISlider *sliderPlay;
@property (weak, nonatomic) IBOutlet UIView *viewPlaySound;
@property (weak, nonatomic) IBOutlet UILabel *labelTotal;
@property (weak, nonatomic) IBOutlet UILabel *labelRemain;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;

@property (nonatomic, strong) STKAudioPlayer* audioPlayer;

@end

static NSString *CellIdentifier = @"TableViewCellIdentifier";

@implementation PHRBookingHistoryViewController {
  
  NSMutableArray *tableData;
  NSTimer* timer;
  int currentIndex;
  int previousIndex;
  int numberOfPage;
  BOOL isFinished;
  BOOL isSelectNewSong;
}

- (void)viewDidLoad {
  [super viewDidLoad];
  
  [self setupAudioPlayer];
  [self setupTimer];
  [self updateControls];
  self.tableView.delegate = self;
  self.tableView.dataSource = self;
  self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
  self.viewPlaySound.backgroundColor = [UIColor colorWithRed:68./255. green:138./255. blue:255./255. alpha:1];
  tableData = [NSMutableArray new];
  UINib *cell = [UINib nibWithNibName:@"BookingHistoryTableViewCell" bundle:nil];
  [self.tableView registerNib:cell forCellReuseIdentifier:CellIdentifier];
  self.refreshControl = [[UIRefreshControl alloc] init];
  [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
  [self.tableView addSubview:self.refreshControl];
  [self.tableView addPullToRefreshWithActionHandler:^{
    [self getBookingListInfo];
  } position:SVPullToRefreshPositionBottom];
  
  currentIndex = -1;
  previousIndex = -1;
  numberOfPage = 1;
  self.sliderPlay.tintColor = [UIColor whiteColor];
  self.sliderPlay.value = 0;
  
  self.labelTotal.font = [FontUtils aileronRegularWithSize:14.f];
  self.labelRemain.font = [FontUtils aileronRegularWithSize:14.f];
  self.labelTotal.textColor = [UIColor whiteColor];
  self.labelRemain.textColor = [UIColor whiteColor];
  self.viewPlaySound.hidden = YES;
  [self.tableView reloadData];
  [self getBookingListInfo];
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

- (void)pullToRefreshData {
  [self resetTableData];
  [self getBookingListInfo];
}

- (void)resetTableData{
  numberOfPage = 1;
  if (tableData.count > 0) {
    [tableData removeAllObjects];
  }
  [self.tableView reloadData];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
  return [tableData count];
}
//
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return TABLE_CELL_HEIGHT;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  BookingHistoryTableViewCell *cell = (BookingHistoryTableViewCell *)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
  
  PHRBookingHistoryModel *model = [tableData objectAtIndex:indexPath.row];
  //NSDate *date = [NSUtils dateFromString: withFormat:PHR_AUDIO_PLAY_FORMAT];
  cell.lblDay.text = model.examinationDateTime;
  cell.lblLength.text = model.duration;
  cell.selectionStyle = UITableViewCellEditingStyleNone;
  if(indexPath.row == currentIndex) {
    cell.backgroundColor = [UIColor colorWithRed:227./255. green:242./255. blue: 252./255. alpha:1];
  } else{
    cell.backgroundColor = [UIColor clearColor];
  }
  return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  self.viewPlaySound.hidden = NO;
  
  PHRBookingHistoryModel *model = [tableData objectAtIndex:indexPath.row];
  
  if (currentIndex == (int)indexPath.row) {
    isSelectNewSong = NO;
    if (model.mediaState == MediaStateContinous) {
      model.mediaState = MediaStatePause;
    } else {
      model.mediaState = MediaStateContinous;
    }
  } else {
    if (currentIndex == -1) {
      isSelectNewSong = NO;
    } else {
      isSelectNewSong = YES;
    }
    
    isFinished = NO;
    previousIndex = currentIndex;
    model.mediaState = MediaStateNewPlay;
    currentIndex = (int)indexPath.row;
    [self.tableView reloadData];
  }
  
  for (int i = 0; i < tableData.count; i++) {
    if (i != indexPath.row) {
      PHRBookingHistoryModel * historyModel = tableData[i];
      historyModel.mediaState = MediaStatePause;
    }
  }
  
  if(model.mediaState == MediaStateNewPlay) {
    [self createAVPlayer:model];
    
  } else if (model.mediaState == MediaStateContinous) {
    [self.audioPlayer resume];
    [self setIconForBtnPlay:YES];
  } else {
    [self.audioPlayer pause];
    [self setIconForBtnPlay:NO];
  }
}


- (BFTask *)bfTaskWithApiMT07With {
  [BaseNetworking configureNetworkingWithHost:[[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host_Mbs"]];
  NSString *urlApiMT07 = [NSString stringWithFormat:API_MT07,
                          _patientClinicAccount.model.hospCode,
                          _patientClinicAccount.model.patientCode,
                          [NSString stringWithFormat:@"%d",numberOfPage],
                          @"10"];
  return [[BaseNetworking sharedInstance] fetchRequest:urlApiMT07
                                                params:nil];
}

- (void)getBookingListInfo {
  [self.viewIndicator setHidden:NO];
   self.lblMessage.hidden = YES;
  [[self bfTaskWithApiMT07With] continueWithBlock:^id _Nullable(BFTask * _Nonnull t) {
    if (t.isCancelled) {
      DLog(@"Cancelled");
    } else if (t.isFaulted) {
      DLog(@"%@", t.error);
    } else {
      [self handleResponseApiMT07:t.result];
    }
    [self.viewIndicator setHidden:YES];
    
    return nil;
  }];
}


- (void)createAVPlayer:(PHRBookingHistoryModel*)model {
  
  self.sliderPlay.value = 0;
  
  NSString *strUrl = model.mtHistoryUrl;
  NSURL *soundUrl = [NSURL URLWithString:strUrl];
  
  //Data Source
  STKDataSource* dataSource = [STKAudioPlayer dataSourceFromURL:soundUrl];
  [self.audioPlayer setDataSource:dataSource withQueueItemId:[[SampleQueueId alloc] initWithUrl:soundUrl andCount:0]];
  //[self setIconForBtnPlay:YES];
  [self updateControls];
}

- (IBAction)onSliderChanged:(id)sender {
  if (self.sliderPlay.value != 1) {
    if (!self.audioPlayer) {
      return;
    }
    [self.audioPlayer seekToTime:self.sliderPlay.value];
    [self setIconForBtnPlay:YES];
  }
}

- (void)handleResponseApiMT07:(NSDictionary *)response {
  
  DLog(@"%@", response);
  if (!response) {
    return;
  }
  id objData = [response objectForKey:@"data"];
  if ([objData isKindOfClass:[NSArray class]]) {
    NSArray *arrData = (NSArray*)objData;
    if (arrData != nil && arrData != (id)[NSNull null] && arrData.count > 0) {
      for (int i = 0 ; i < arrData.count; i++) {
        NSDictionary *dict = [arrData objectAtIndex:i];
        PHRBookingHistoryModel *bookingModel = [[PHRBookingHistoryModel alloc ] initWithDictionary:dict];
        [tableData addObject:bookingModel];
      }
    }
    numberOfPage += 1;
    [_tableView reloadData];
  } else if ([objData isKindOfClass:[NSString class]]) {
    if (tableData.count == 0) {
      self.lblMessage.text = kLocalizedString(objData);
      self.lblMessage.hidden = NO;
    }
  }
  
  [self.refreshControl endRefreshing];
  [self.tableView.pullToRefreshView stopAnimating];
}

- (IBAction)onClickBtnPause:(id)sender {
  
  if (!self.audioPlayer || currentIndex == -1) {
    return;
  }
  
  if (self.audioPlayer.state == STKAudioPlayerStatePaused) {
    [self.audioPlayer resume];
  } else {
    [self.audioPlayer pause];
  }
}

- (void)setIconForBtnPlay:(BOOL)isPlaying {
  if (isPlaying) {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_pause.png"] forState:UIControlStateNormal];
    });
  } else {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_play_mp3.png"] forState:UIControlStateNormal];
    });
  }
}
- (IBAction)onClickBtnPrevious:(id)sender {
  if (tableData.count == 0) {
    return;
  }
  previousIndex = currentIndex;
  PHRBookingHistoryModel *modelPreviousCurrent = [tableData objectAtIndex:previousIndex];
  modelPreviousCurrent.mediaState  = MediaStatePause;
  currentIndex = (currentIndex - 1) % (tableData.count);
  PHRBookingHistoryModel *model = [tableData objectAtIndex:currentIndex];
  model.mediaState = MediaStateNewPlay;
  [self createAVPlayer:model];
  [self.tableView reloadData];
  
}

- (IBAction)onClickBtnNext:(id)sender {
  if (tableData.count == 0) {
    return;
  }
  previousIndex = currentIndex;
  PHRBookingHistoryModel *modelPreviousCurrent = [tableData objectAtIndex:previousIndex];
  modelPreviousCurrent.mediaState  = MediaStatePause;
  currentIndex = (currentIndex  + 1) % (tableData.count);
  PHRBookingHistoryModel *model = [tableData objectAtIndex:currentIndex];
  model.mediaState = MediaStateNewPlay;
  [self createAVPlayer:model];
  [self.tableView reloadData];
}

-(NSString*) formatTimeFromSeconds:(int)totalSeconds {
  
  int seconds = totalSeconds % 60;
  int minutes = (totalSeconds / 60) % 60;
  int hours = totalSeconds / 3600;
  
  return [NSString stringWithFormat:@"%02d:%02d:%02d", hours, minutes, seconds];
}

- (void)setupTimer {
  timer = [NSTimer timerWithTimeInterval:0.001 target:self selector:@selector(tick) userInfo:nil repeats:YES];
  
  [[NSRunLoop currentRunLoop] addTimer:timer forMode:NSRunLoopCommonModes];
}

- (void)tick {
  if (!self.audioPlayer) {
    self.sliderPlay.value = 0;
    return;
  }
  
  if (self.audioPlayer.currentlyPlayingQueueItemId == nil) {
    self.sliderPlay.value = 0;
    self.sliderPlay.minimumValue = 0;
    self.sliderPlay.maximumValue = 0;
    return;
  }
  
  if (self.audioPlayer.duration != 0) {
    self.sliderPlay.minimumValue = 0;
    self.sliderPlay.maximumValue = self.audioPlayer.duration;
    self.sliderPlay.value = self.audioPlayer.progress;
    //    self.labelTotal.text = [NSString stringWithFormat:@"%@",[self formatTimeFromSeconds:self.audioPlayer.duration]];
    if (currentIndex != -1 && currentIndex < tableData.count) {
      PHRBookingHistoryModel *model  = tableData[currentIndex];
      self.labelTotal.text = model.duration;
    }
    
    self.labelRemain.text = [NSString stringWithFormat:@"%@", [self formatTimeFromSeconds:self.audioPlayer.progress]];
  } else {
    self.sliderPlay.value = 0;
    self.sliderPlay.minimumValue = 0;
    self.sliderPlay.maximumValue = 0;
    
    // label.text =  [NSString stringWithFormat:@"Live stream %@", [self formatTimeFromSeconds:audioPlayer.progress]];
  }
  
  //statusLabel.text = self.audioPlayer.state == STKAudioPlayerStateBuffering ? @"buffering" : @"";
  
  //CGFloat newWidth = 320 * (([self.audioPlayer averagePowerInDecibelsForChannel:1] + 60) / 60);
  
  //meter.frame = CGRectMake(0, 460, newWidth, 20);
}

-(void)updateControls {
  if (self.audioPlayer == nil) {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_play_mp3"] forState:UIControlStateNormal];
    });
  }
  else if (self.audioPlayer.state == STKAudioPlayerStatePaused) {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_play_mp3"] forState:UIControlStateNormal];
    });
  }
  else if (self.audioPlayer.state & STKAudioPlayerStatePlaying) {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_pause.png"] forState:UIControlStateNormal];
    });
  } else if (self.audioPlayer.state & STKAudioPlayerStateReady) {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_play_mp3"] forState:UIControlStateNormal];
    });
  } else {
    dispatch_async(dispatch_get_main_queue(), ^{
      [_btnAction setImage:[UIImage imageNamed:@"ic_play_mp3"] forState:UIControlStateNormal];
    });
  }
  
  [self tick];
}

- (void) audioPlayer:(STKAudioPlayer*)audioPlayer stateChanged:(STKAudioPlayerState)state previousState:(STKAudioPlayerState)previousState {
  
  [self updateControls];
}

- (void) audioPlayer:(STKAudioPlayer*)audioPlayer unexpectedError:(STKAudioPlayerErrorCode)errorCode {
  [self updateControls];
}

- (void) audioPlayer:(STKAudioPlayer*)audioPlayer didStartPlayingQueueItemId:(NSObject*)queueItemId {
  if (isFinished) {
    isFinished = NO;
    [self.audioPlayer pause];
    return;
  }
  SampleQueueId* queueId = (SampleQueueId*)queueItemId;
  
  NSLog(@"Started: %@", [queueId.url description]);
  
  [self updateControls];
}

- (void) audioPlayer:(STKAudioPlayer*)audioPlayer didFinishBufferingSourceWithQueueItemId:(NSObject*)queueItemId {
  [self updateControls];
}

- (void) audioPlayer:(STKAudioPlayer*)audioPlayer didFinishPlayingQueueItemId:(NSObject*)queueItemId withReason:(STKAudioPlayerStopReason)stopReason andProgress:(double)progress andDuration:(double)duration {
  
  SampleQueueId* queueId = (SampleQueueId*)queueItemId;
  
  if (isSelectNewSong) {
    isFinished = NO;
    isSelectNewSong = NO;
  } else {
    [self.audioPlayer queueDataSource:[STKAudioPlayer dataSourceFromURL:queueId.url] withQueueItemId:[[SampleQueueId alloc] initWithUrl:queueId.url andCount:0]];
    isFinished = YES;
  }
  
  
  
  // NSLog(@"Finished: %@", [queueId.url description]);
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
