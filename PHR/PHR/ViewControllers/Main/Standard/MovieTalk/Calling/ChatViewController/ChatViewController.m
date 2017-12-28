//
//  ChatViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChatViewController.h"

@interface ChatViewController ()

@end

@implementation ChatViewController {
  NSString *SENDER_ID;
}

- (void)viewDidLoad {
  
  [super viewDidLoad];
  [self setupView];
  
}

- (void)setupView {
  
  [self setupChatView];
  [self setupData];
}

- (void)setupChatView {
  
  self.senderDisplayName = @"";
  self.inputToolbar.contentView.textView.pasteDelegate = self;
  self.inputToolbar.contentView.textView.backgroundColor = [UIColor whiteColor];
  self.inputToolbar.contentView.textView.layer.borderColor = PHR_COLOR_GRAY.CGColor;
  self.inputToolbar.contentView.textView.layer.borderWidth = 1;
  self.inputToolbar.contentView.textView.layer.cornerRadius = 20;
  self.inputToolbar.contentView.textView.backgroundColor = [UIColor whiteColor];
  self.inputToolbar.contentView.textView.placeHolder = kLocalizedString(kTextMessage);
  
  self.collectionView.backgroundColor = [UIColor whiteColor];
  self.inputToolbar.tintColor = [UIColor blackColor];
  self.automaticallyScrollsToMostRecentMessage = YES;
  
  self.collectionView.collectionViewLayout.incomingAvatarViewSize = CGSizeMake(0.0, 0.0);
  self.collectionView.collectionViewLayout.outgoingAvatarViewSize = CGSizeMake(0.0, 0.0);
  self.showLoadEarlierMessagesHeader = NO;
  self.collectionView.collectionViewLayout.messageBubbleFont = [FontUtils aileronRegularWithSize:14];
}

- (void)setupData {
  
  self.messageModel = [[MessageModel alloc] init];
  self.messageModel.profileId = PHRAppStatus.currentStandard.profileId;
  SENDER_ID = @"SenderDisplayName";
  self.senderId = SENDER_ID;
}

- (void)viewWillLayoutSubviews{
  [super viewWillLayoutSubviews];
  //TungNT: call this to collectionview can get new width
  dispatch_async(dispatch_get_main_queue(), ^ {
   [self.collectionView reloadData];
  });
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  
}

- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];
  self.collectionView.collectionViewLayout.springinessEnabled = NO;
}
- (void)handleIncomingMessage:(NSString*)incomingMessage {
  
  if (!incomingMessage || incomingMessage.isEmpty) {
    return;
  }
  
  JSQMessage *jsqMessage = [self createMessageModel:incomingMessage isIncomingMessage:YES isSendSuccessfully:YES];
  [self.messageModel.messages addObject:jsqMessage];
  self.messageModel.messages = [self timeSortedForJQMessage:self.messageModel.messages];
  dispatch_async(dispatch_get_main_queue(), ^ {
    [self finishReceivingMessageAnimated:YES];
  });
}

- (void)handleSendMessage:(NSString*)sendingMessage {
  
  BOOL isSendMessageSucces = NO;
  if (!sendingMessage || sendingMessage.isEmpty) {
    return;
  }
  if (MovieTalkManager.dataConnection) {
    isSendMessageSucces = [MovieTalkManager.dataConnection send:sendingMessage];
  }
  JSQMessage *jsqMessage = [self createMessageModel:sendingMessage isIncomingMessage:NO isSendSuccessfully:isSendMessageSucces];
  [self.messageModel.messages addObject:jsqMessage];
  self.messageModel.messages = [self timeSortedForJQMessage:self.messageModel.messages];
  [self finishSendingMessageAnimated:YES];
}

- (JSQMessage*)createMessageModel:(NSString*)message isIncomingMessage:(BOOL)isIncomingMessage isSendSuccessfully:(BOOL)isSendSuccessfully {
  
  NSString *senderID;
  if (isIncomingMessage) {
    senderID = @"other";
  } else {
    senderID = SENDER_ID;
  }
  JSQMessage *messageModel = [[JSQMessage alloc] initWithSenderId:senderID senderDisplayName:@"" date:[NSDate date] text:message isSendSuccessfully:isSendSuccessfully];
  return messageModel;
}

- (NSMutableArray *) timeSortedForJQMessage:(NSMutableArray *)array {
  
  NSMutableArray* begins = array;
  NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"date" ascending:YES];
  [begins sortUsingDescriptors: @[sort]];
  return begins;
}

- (void)reloadUI {
  
  [self.collectionView setContentOffset:CGPointMake(0,0) animated:YES]; // trigger refreshcontrol - STOP
  [self finishSendingMessageAnimated:YES];
}

#pragma mark - JSQMessagesViewController method overrides

- (void)didPressSendButton:(UIButton *)button withMessageText:(NSString *)text senderId:(NSString *)senderId senderDisplayName:(NSString *)senderDisplayName date:(NSDate *)date {
  
  int length = 128;
  if (!text || [text length] > length) {
    [NSUtils showMessage:[NSString stringWithFormat:kLocalizedString(kTextInputLong),@(length).stringValue] withTitle:APP_NAME];
    return;
  }
  [self handleSendMessage:text];
  self.inputToolbar.contentView.textView.text = @"";
}


#pragma mark - JSQMessages CollectionView DataSource

- (id<JSQMessageData>)collectionView:(JSQMessagesCollectionView *)collectionView messageDataForItemAtIndexPath:(NSIndexPath *)indexPath {
  return [self.messageModel.messages objectAtIndex:indexPath.item];
}

- (void)collectionView:(JSQMessagesCollectionView *)collectionView didDeleteMessageAtIndexPath:(NSIndexPath *)indexPath{
  [self.messageModel.messages removeObjectAtIndex:indexPath.item];
}

- (id<JSQMessageBubbleImageDataSource>)collectionView:(JSQMessagesCollectionView *)collectionView messageBubbleImageDataForItemAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  You may return nil here if you do not want bubbles.
   *  In this case, you should set the background color of your collection view cell's textView.
   *
   *  Otherwise, return your previously created bubble image data objects.
   */
  
  JSQMessage *message = [self.messageModel.messages objectAtIndex:indexPath.item];
  
  if ([message.senderId isEqualToString:self.senderId]) {
    return self.messageModel.outgoingBubbleImageData;
  }
  
  return self.messageModel.incomingBubbleImageData;
}

- (id<JSQMessageAvatarImageDataSource>)collectionView:(JSQMessagesCollectionView *)collectionView avatarImageDataForItemAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  Return `nil` here if you do not want avatars.
   *  If you do return `nil`, be sure to do the following in `viewDidLoad`:
   *
   *  self.collectionView.collectionViewLayout.incomingAvatarViewSize = CGSizeZero;
   *  self.collectionView.collectionViewLayout.outgoingAvatarViewSize = CGSizeZero;
   *
   *  It is possible to have only outgoing avatars or only incoming avatars, too.
   */
  
  /**
   *  Return your previously created avatar image data objects.
   *
   *  Note: these the avatars will be sized according to these values:
   *
   *  self.collectionView.collectionViewLayout.incomingAvatarViewSize
   *  self.collectionView.collectionViewLayout.outgoingAvatarViewSize
   *
   *  Override the defaults in `viewDidLoad`
   */
  //    MessageModel *messageModel = [self.arrayReceivedMessage objectAtIndex:indexPath.item];
  //	NSString* senderIdForAvatar = [NSString stringWithFormat:@"%@%@",messageModel.chatId,messageModel.type];
  return nil;
}

- (NSAttributedString *)collectionView:(JSQMessagesCollectionView *)collectionView attributedTextForCellTopLabelAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  This logic should be consistent with what you return from `heightForCellTopLabelAtIndexPath:`
   *  The other label text delegate methods should follow a similar pattern.
   *
   *  Show a timestamp for every 3rd message
   */
  if (indexPath.item % 3 == 0) {
     JSQMessage *message = [self.messageModel.messages objectAtIndex:indexPath.item];
    //return [[JSQMessagesTimestampFormatter sharedFormatter] attributedTimestampForDate:message.date];
    //TungNT: no need to show time
    return [[NSAttributedString alloc] initWithString:[UIUtils remiderTimeStringFromDate:message.date]];
  }
  
  return nil;
}

- (NSAttributedString *)collectionView:(JSQMessagesCollectionView *)collectionView attributedTextForMessageBubbleTopLabelAtIndexPath:(NSIndexPath *)indexPath{
  JSQMessage *message = [self.messageModel.messages objectAtIndex:indexPath.item];
  
  /**
   *  iOS7-style sender name labels
   */
  if ([message.senderId isEqualToString:self.senderId]) {
    return nil;
  }
  
  if (indexPath.item - 1 > 0) {
    JSQMessage *previousMessage = [self.messageModel.messages objectAtIndex:indexPath.item - 1];
    if ([[previousMessage senderId] isEqualToString:message.senderId]) {
      return nil;
    }
  }
  
  /**
   *  Don't specify attributes to use the defaults.
   */
  //return [[NSAttributedString alloc] initWithString:message.senderDisplayName];
  //TungNT: no need to show username
  return nil;
}

- (NSAttributedString *)collectionView:(JSQMessagesCollectionView *)collectionView attributedTextForCellBottomLabelAtIndexPath:(NSIndexPath *)indexPath {
  //TungNT: show bottom text
  JSQMessage *message = [self.messageModel.messages objectAtIndex:indexPath.item];
  if (message.isSendSuccessfully) {
    return nil;
  } else {
    return [[NSAttributedString alloc] initWithString:kLocalizedString(kNotDelivered)];
  }
}

#pragma mark - UICollectionView DataSource

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section{
  NSLog(@"[self.demoData.messages count]: %ld",[self.messageModel.messages count]);
  return [self.messageModel.messages count];
}

- (UICollectionViewCell *)collectionView:(JSQMessagesCollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  Override point for customizing cells
   */
  /**
   *  Configure almost *anything* on the cell
   *
   *  Text colors, label text, label colors, etc.
   *
   *
   *  DO NOT set `cell.textView.font` !
   *  Instead, you need to set `self.collectionView.collectionViewLayout.messageBubbleFont` to the font you want in `viewDidLoad`
   *
   *
   *  DO NOT manipulate cell layout information!
   *  Instead, override the properties you want on `self.collectionView.collectionViewLayout` from `viewDidLoad`
   */
  
  NSLog(@"indexPath.row: %ld",indexPath.row);
  JSQMessagesCollectionViewCell *cell = (JSQMessagesCollectionViewCell *)[super collectionView:collectionView cellForItemAtIndexPath:indexPath];
  JSQMessage *msg = [self.messageModel.messages objectAtIndex:indexPath.item];
  
  cell.avatarImageView.image = nil;

  if ([msg.senderId isEqualToString:self.senderId]) {
    cell.textView.textColor = PHR_COLOR_GRAY;
  } else {
    cell.textView.textColor = PHR_COLOR_GRAY;
  }
  cell.textView.text = msg.text;
  cell.cellBottomLabel.textColor = [UIColor redColor];
  cell.cellBottomLabel.font = [FontUtils aileronRegularWithSize:12.0];

  return cell;
}



#pragma mark - UICollectionView Delegate

#pragma mark - Custom menu items
- (BOOL)collectionView:(UICollectionView *)collectionView canPerformAction:(SEL)action forItemAtIndexPath:(NSIndexPath *)indexPath withSender:(id)sender {
  return [super collectionView:collectionView canPerformAction:action forItemAtIndexPath:indexPath withSender:sender];
}

- (void)collectionView:(UICollectionView *)collectionView performAction:(SEL)action forItemAtIndexPath:(NSIndexPath *)indexPath withSender:(id)sender {
  [super collectionView:collectionView performAction:action forItemAtIndexPath:indexPath withSender:sender];
}

#pragma mark - Adjusting cell label heights

- (CGFloat)collectionView:(JSQMessagesCollectionView *)collectionView
                   layout:(JSQMessagesCollectionViewFlowLayout *)collectionViewLayout heightForCellTopLabelAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  Each label in a cell has a `height` delegate method that corresponds to its text dataSource method
   */
  
  /**
   *  This logic should be consistent with what you return from `attributedTextForCellTopLabelAtIndexPath:`
   *  The other label height delegate methods should follow similarly
   *
   *  Show a timestamp for every 3rd message
   */
  //    if (indexPath.item % 3 == 0) {
  //        return kJSQMessagesCollectionViewCellLabelHeightDefault;
  //    }
  
  return (CGFloat) kJSQMessagesCollectionViewCellLabelHeightDefault / 2.0;
}

- (CGFloat)collectionView:(JSQMessagesCollectionView *)collectionView
                   layout:(JSQMessagesCollectionViewFlowLayout *)collectionViewLayout heightForMessageBubbleTopLabelAtIndexPath:(NSIndexPath *)indexPath{
  /**
   *  iOS7-style sender name labels
   */
  JSQMessage *currentMessage = [self.messageModel.messages objectAtIndex:indexPath.item];
  if ([[currentMessage senderId] isEqualToString:self.senderId]) {
    return 0.0f;
  }
  
  if (indexPath.item - 1 > 0) {
    JSQMessage *previousMessage = [self.messageModel.messages objectAtIndex:indexPath.item - 1];
    if ([[previousMessage senderId] isEqualToString:[currentMessage senderId]]) {
      return 0.0f;
    }
  }
  //TungNT: no need top label show set its height = 0
  return 0.0f;
}

- (CGFloat)collectionView:(JSQMessagesCollectionView *)collectionView layout:(JSQMessagesCollectionViewFlowLayout *)collectionViewLayout heightForCellBottomLabelAtIndexPath:(NSIndexPath *)indexPath{
  return (CGFloat) kJSQMessagesCollectionViewCellLabelHeightDefault / 2.0;
}

#pragma mark - Responding to collection view tap events

- (void)collectionView:(JSQMessagesCollectionView *)collectionView didTapAvatarImageView:(UIImageView *)avatarImageView atIndexPath:(NSIndexPath *)indexPath{
  NSLog(@"Tapped avatar!");
}

- (void)collectionView:(JSQMessagesCollectionView *)collectionView didTapMessageBubbleAtIndexPath:(NSIndexPath *)indexPath{
  NSLog(@"Tapped message bubble!");
}

- (void)collectionView:(JSQMessagesCollectionView *)collectionView didTapCellAtIndexPath:(NSIndexPath *)indexPath touchLocation:(CGPoint)touchLocation{
  NSLog(@"Tapped cell at %@!", NSStringFromCGPoint(touchLocation));
  //TungNT: dismiss keyboard if touch on cell but outside of bubble
  [self.inputToolbar.contentView.textView resignFirstResponder];
}

#pragma mark - JSQMessagesComposerTextViewPasteDelegate methods


- (BOOL)composerTextView:(JSQMessagesComposerTextView *)textView shouldPasteWithSender:(id)sender
{
  if ([UIPasteboard generalPasteboard].image) {
    // If there's an image in the pasteboard, construct a media item with that image and `send` it.
    //        JSQPhotoMediaItem *item = [[JSQPhotoMediaItem alloc] initWithImage:[UIPasteboard generalPasteboard].image];
    JSQMessage *message = [[JSQMessage alloc] initWithSenderId:self.senderId
                                             senderDisplayName:self.senderDisplayName
                                                          date:[NSDate date]];
    [self.messageModel.messages addObject:message];
    [self finishSendingMessage];
    return NO;
  }
  return YES;
}


@end
