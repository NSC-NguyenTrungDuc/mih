<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>

<c:url var="imageUrl" value="/assets/img"/>

<!-- BEGIN Home Slider -->
<div class="home-slider">
  <div class="slide slide-01">
	<div class="container">
	  <div class="row">
		<div class="col-md-12">
		  <div class="middle-text">
			<h3 class="title animated fadeInDown"><span class="span-break">あなたのカルテを</span>命のために。</h3>
		  </div>
		</div>
	  </div>
	</div>            
	
  </div>
  <a href="#" class="scroll-down">&nbsp;</a>
</div><!-- END Home Slider -->
<!-- BEGIN Intro Section -->
<div class="intro-section">
  <div class="container">
	<div class="row">
	  <div class="col-md-12">
		<div class="intro-area">
		  <!-- BEGIN Intro Row 1 -->
		  <div class="intro-row clearfix">
			<div class="intro-block intro-block-a15">
			  <h2 class="intro-title" data-sr='enter top, move 24px'>あなたの医療情報が<br><strong>未来の誰かの治療</strong>を<span class="no-breaking-word">支えます</span></h2>
			</div>
			<div class="intro-block intro-block-a6">                      
			  <img src="${imageUrl}/intro/a6.jpg" alt="" data-sr='over 0.6s'>
			</div>
		  </div><!-- END Intro Row 1 -->
		  <!-- BEGIN Intro Row 2 -->
		  <div class="intro-row clearfix">
			<div class="intro-block intro-block-b13">
			  <p class="intro-desc">あなたやご家族の診療記録。それは大切な個人情報です。 しかし、将来、誰かが同じ病気や症状で<span class="no-breaking-word">お困り</span>になった<span class="no-breaking-word">際に</span>どんな<span class="no-breaking-word">治療</span>の 効果があったのかを知るための大切な情報でもあります。<br> わたしたちのクラウドカルテサービスは、皆様の<span class="no-breaking-word">診療記録</span>をお預かりし、活用する<span class="no-breaking-word">ことで</span>、未来の誰かの治療に役立てたいと考えています。</p>
			</div>
			<div class="intro-block intro-block-b4">
			  <img src="${imageUrl}/intro/b4.jpg" alt="" data-sr='over 0.6s'>
			</div>
			<div class="intro-block intro-block-b5">
			  <img src="${imageUrl}/intro/b5.jpg" alt="" data-sr='wait 0.5s, over 0.6s'>
			</div>
			<div class="intro-block intro-block-b6">
			  <img src="${imageUrl}/intro/b6.jpg" alt="" data-sr='over 0.6s'>
			</div>
		  </div><!-- END Intro Row 2 -->
		  <!-- BEGIN Intro Row 3 -->
		  <div class="intro-row clearfix">
			<div class="intro-block intro-block-c1">
			  <img src="${imageUrl}/intro/c1.jpg" alt="" data-sr='over 0.6s'>
			</div>
			<div class="intro-block intro-block-c2">
			  <img src="${imageUrl}/intro/c2.jpg" alt="" data-sr='wait 0.5s, over 0.6s'>
			</div>
			<div class="intro-block intro-block-c3">
			  <img src="${imageUrl}/intro/c3.jpg" alt="" data-sr='over 0.6s'>
			</div>
			<div class="intro-block intro-block-c4">
			  <img src="${imageUrl}/intro/c4.jpg" alt="" data-sr='wait 0.2s, over 0.6s'>
			</div>
			<div class="intro-block intro-block-c5"></div>
			<div class="intro-block intro-block-c6">
			  <img src="${imageUrl}/intro/c6.jpg" alt="" data-sr='over 0.6s'>
			</div>
		  </div><!-- END Intro Row 3 -->
		  <!-- BEGIN Intro Row 4 -->
		  <div class="intro-row clearfix">
			<div class="intro-block intro-block-d1"></div>
			<div class="intro-block intro-block-d2">
			  <img src="${imageUrl}/intro/d2.jpg" alt="" data-sr='wait 0.5s, over 0.6s'>
			</div>
			<div class="intro-block intro-block-d3">
			  <img src="${imageUrl}/intro/d3.jpg" alt="" class="hdimg">
			</div>
			<div class="intro-block intro-block-d45">
			  <img src="${imageUrl}/intro/d45.jpg" alt="" data-sr='over 0.6s'>
			</div>
			<div class="intro-block intro-block-d6">
			  <img src="${imageUrl}/intro/d6.jpg" alt="" class="hdimg">
			</div>                    
		  </div><!-- END Intro Row 4 -->
		  <!-- BEGIN Intro Row 5 -->
		  <div class="intro-row clearfix">
			<div class="intro-block intro-block-e12"></div>
			<div class="intro-block intro-block-e3">
			  <img src="${imageUrl}/intro/e3.jpg" alt="" data-sr='over 0.6s'>
			</div>
			<div class="intro-block intro-block-e45">
			  <blockquote class="intro-blockquote">未来の医療が<br>すぐそこまで来ています。</blockquote>
			</div>  
			<div class="intro-block intro-block-e6">                      
			  <img src="${imageUrl}/intro/e6.jpg" alt="" class="hdimg">
			</div>                                   
		  </div><!-- END Intro Row 5 -->
		</div>
	  </div>
	</div>
  </div>
</div><!-- END Intro Section -->

<!-- BEGIN Chart Section-->
<div class="chart-section">
  <div class="container">
	<div class="row">
	  <div class="col-md-12">
		<h3 class="section-title"><span class="main-text">無料の理由</span> データ量が増えるほど、病気の数を減らすことができます。</h3>
		<div class="chart-wrap clearfix">
		  <img data-src-base='${imageUrl}/' data-src='<992:chart-bg-2.jpg,>992:chart-bg.jpg' class="chart-bg">
		  <noscript><img alt="" src="${imageUrl}/chart-bg.jpg" /></noscript>                  
		  <img src="${imageUrl}/chart-line-blue.png" alt="" class="chart-line-blue" data-sr="enter">
		  <img src="${imageUrl}/chart-line-green.png" alt="" class="chart-line-green" data-sr="wait 0.5s, enter">
		  <img src="${imageUrl}/chart-line-red.png" alt="" class="chart-line-red" data-sr="wait 0.6s, enter">
		  <img src="${imageUrl}/chart-note.png" alt="" class="chart-note" data-sr="wait 0.9s, enter">
		</div>
	  </div>
	</div>
	<div class="row">
	  <div class="col-md-7">
		<div class="row">
		  <div class="col-xs-4">  
			<div class="chart-ibox ibox1">
			  クリニック参加数
			</div>
		  </div>
		  <div class="col-xs-4">
			<div class="chart-ibox ibox2">
			 電子カルテ件数
			</div>
		  </div>
		  <div class="col-xs-4">
			<div class="chart-ibox ibox3">
			  病気の件数
			</div>
		  </div>
		</div>
	  </div>
	  <div class="col-md-5">
		<div class="chart-ibox-text clearfix">
		  <h3>KARTE.CLINICは無料の電子<span class="no-breaking-word">カルテ</span>を提供します</h3>
		  <p>ビッグデータを活用した医療情報の活用にはデータの件数がもっとも重要です。<br>
			たくさんのクリニックの皆様に参加していただきたいから、KARTE.CLINICは無料の電子カルテの提供を<span class="no-breaking-word">始めます。</span></p>  
		</div>
	  </div>
	</div>
  </div>
</div><!-- END Chart Section-->

<!-- BEGIN list Items -->
<div class="list-home-items">
  <div class="container">
	<div class="row">
	  <div class="col-md-12">
		<!-- BEGIN Item 01 -->                
		<div class="item item-01 clearfix" data-sr="over 0.6s">
		  <div class="feature">                    
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization1_o.jpg,>767:realization1.jpg'>  
			<noscript><img alt="" src="${imageUrl}/temp/realization1.jpg" /></noscript>                      
			<div class="box-color1"></div>
		  </div>
		  <header class="item-header">
			<h3 class="item-title">
			  医療機関の皆様に役立つ<br>
			  <strong><span class="no-breaking-word">情報</span>の<span class="no-breaking-word">共有</span></strong>を実現します。</h3>
		  </header>
		  <div class="item-summary">
			<p>今年のインフルエンザウィルスの流行はどのエリア<span class="no-breaking-word">から</span>始<span class="no-breaking-word">まって</span>いるのか、どれぐらいの勢いで広まっているのか。薬はどれぐらい<span class="no-breaking-word">必要</span>なのか。<br>
			  新しいウイルスではどんな症状が出ているのか、その処方にはどのような 治療が有効なのか。<br>
			  そんな情報をクラウドカルテのデータから<span class="no-breaking-word">分析</span>して、医療機関の皆様に 共有します。</p>
		  </div>
		</div><!-- END Item 01--> 
		<!-- BEGIN Item 02 -->                
		<div class="item item-02 clearfix" data-sr="over 0.6s">
		  <div class="feature">                    
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization2_o.jpg,>767:realization2.jpg'> 
			<noscript><img alt="" src="${imageUrl}/temp/realization2.jpg" /></noscript>   
			<div class="box-color1"></div>
		  </div>
		  <header class="item-header">
			<h3 class="item-title">
			  「あなたの<br>
			  <strong>生涯カルテ</strong>」<br>
			  をおつくりします。</h3>
		  </header>
		  <div class="item-summary">
			<p>今年のインフルエンザウィルスの流行はどのエリアから始<span class="no-breaking-word">まって</span>いるのか、どれぐらいの勢いで広まっているのか。薬はどれぐらい<span class="no-breaking-word">必要</span>なのか。<br>
			  新しいウイルスではどんな症状が出ているのか、その処方にはどのような 治療が有効なのか。<br>
			  そんな情報をクラウドカルテのデータから<span class="no-breaking-word">分析</span>して、<span class="no-breaking-word">医療機関</span>の皆様に 共有します。</p>
		  </div>
		</div><!-- END Item 02--> 
		<!-- BEGIN Item 03 -->                
		<div class="item item-03 clearfix" data-sr="over 0.6s">
		  <div class="feature">
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization3_o.jpg,>767:realization3.jpg'>
			<noscript><img alt="" src="${imageUrl}/temp/realization3.jpg" /></noscript>  
			<div class="box-color1"></div>
			<div class="box-color2"></div>
		  </div>
		  <header class="item-header">
			<h3 class="item-title">
			  医療<strong>ビッグデ</strong><br>
			  <strong>ータ</strong>の活用を<br>
			  推進<span class="no-breaking-word">します。</span></h3>
		  </header>
		  <div class="item-summary">
			<p>「ビッグデータ分析」という手法が登場し、論理的<span class="no-breaking-word">思考</span>では予想できなかったような事実が発見されています。集積した診療データを分析することで、いままで知らなかった薬品の効果が発見されたり、副作用が<span class="no-breaking-word">発見</span>されたりしています。<span class="no-breaking-word">また、</span>地域による違いや、<span class="no-breaking-word">その他の</span>傾向にかかる病気の偏りなどを発見することができます。クラウドカルテはその<span class="no-breaking-word">分析</span>の基礎となるデータを提供し、活用を<span class="no-breaking-word">促進</span>してまいります。</p>
		  </div>
		</div><!-- END Item 03-->
		<!-- BEGIN Item 04 -->                
		<div class="item item-04 clearfix" data-sr="over 0.6s">
		  <div class="feature">
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization4a_o.jpg,>767:realization4a.jpg'> 
			<noscript><img alt="" src="${imageUrl}/temp/realization4a.jpg" /></noscript> 
			<div class="box-color1"></div>                  
		  </div>                  
		  <header class="item-header">
			<h3 class="item-title">
			 <strong>いま必要</strong>な<br>
			  医療情報を<br>
			  提供し<span class="no-breaking-word">ます。</span></h3>
		  </header>
		  <div class="item-summary">
			<p>子供が急に痛みや発熱を訴えたときに<span class="no-breaking-word">どういう</span>対処をするのが最適なのか。<br>
			救急時に慌てることなく最適な対処ができるように<span class="no-breaking-word">蓄積</span>されたデータから最適な情報提供を実施していきます。<br>
			予約システムを充実させ、24時間緊急対応してくれるお医者様の情報を提案していき<span class="no-breaking-word">ます。</span></p>
		  </div>
		  <div class="box-img">
			<img src="${imageUrl}/temp/realization4b.jpg" alt=""> 
			<div class="box-color"></div> 
		  </div>                  
		</div><!-- END Item 04--> 
		<!-- BEGIN Item 05 -->                
		<div class="item item-05 clearfix" data-sr="over 0.6s">
		  <div class="feature">                    
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization5a_o.jpg,>767:realization5a.jpg'> 
			<noscript><img alt="" src="${imageUrl}/temp/realization5a.jpg" /></noscript> 
			<div class="box-color1"></div>     
			<div class="box-color2"></div>                  
		  </div>                  
		  <header class="item-header">
			<h3 class="item-title">
			 <strong>地域医療連携</strong>を<br>
			  実現<span class="no-breaking-word">します。</span></h3>
		  </header>
		  <div class="item-summary">
			<p>クラウドカルテを利用している医療機関、<span class="no-breaking-word">治療機関</span>のあいだでのデータの連携を実現します。患者様の同意に基づき、<span class="no-breaking-word">患者様の</span><span class="no-breaking-word">カルテデータ</span>を紹介先のドクターにお知らせします。これにより地域内の医療連携や、<span class="no-breaking-word">遠隔医療</span>などの実現に寄与することができ<span class="no-breaking-word">ます。</span></p>
		  </div>
		  <div class="box-img">
			<img src="${imageUrl}/temp/realization5b.jpg" alt="">                    
			<div class="box-color"></div> 
		  </div>                  
		</div><!-- END Item 05-->
		<!-- BEGIN Item 06 -->                
		<div class="item item-06 clearfix" data-sr="over 0.6s">
		  <div class="feature">                      
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization6_o.jpg,>767:realization6.jpg'> 
			<noscript><img alt="" src="${imageUrl}/temp/realization6.jpg" /></noscript> 
			<div class="box-color1"></div>                      
		  </div>                  
		  <header class="item-header">
			<h3 class="item-title">
			<strong>便利な医療</strong><br>
			<strong>環境</strong>の提供に<br>
			<span class="no-breaking-word">寄与</span>し<span class="no-breaking-word">ます。</span></h3>
		  </header>
		  <div class="item-summary">
			<p>「電子処方箋」ということばを聞いたことがありますか？<span class="no-breaking-word">いわゆ</span>る処方箋を電子的に配布することです。<span class="no-breaking-word">処方箋</span>が<span class="no-breaking-word">電子化</span>することで、病院の前、病院の近くの<span class="no-breaking-word">調剤薬局</span>ではなく、家の近所の調剤薬局でお薬を<span class="no-breaking-word">受け取る</span>ことができるようになります。<br>
			病院の帰りにちょっとしたお買い物をしているあいだに近所の調剤薬局でお薬の準備を<span class="no-breaking-word">して</span>おいてもらう。そんなことを実現していくことができます</p>
		  </div>                                    
		</div><!-- END Item 06-->
		<!-- BEGIN Item 06 -->                
		<div class="item item-07 clearfix" data-sr="over 0.6s">
		  <div class="feature">
			<img data-src-base='${imageUrl}/temp/' data-src='<767:realization7_o.jpg,>767:realization7.jpg'>
			<noscript><img alt="" src="${imageUrl}/temp/realization7.jpg" /></noscript> 
			<div class="box-color1"></div> 
			<div class="box-color2"></div>                      
		  </div>                  
		  <header class="item-header">
			<h3 class="item-title">
			<strong>健康で豊かな生活</strong>の<br>
			<span class="no-breaking-word">サポート</span>を<span class="no-breaking-word">します。</span></h3>
		  </header>
		  <div class="item-summary">
			<p>ウェアラブル端末を利用した脈拍、<span class="no-breaking-word">運動データ</span>取得やDNA<span class="no-breaking-word">鑑定</span>など、“病気にかからないためのデータ”を<span class="no-breaking-word">利用</span>する取組が始まっています。<br>クラウドカルテのデータをこれらのデータと連携することで、成人病などの病気を未然に防ぎ、健康で豊かな生活を<span class="no-breaking-word">サポート</span>するためのご提案を実現していき<span class="no-breaking-word">ます。</span></p>
		  </div>                                    
		</div><!-- END Item 06--> 
	  </div>
	</div>
  </div>
</div><!-- END List Items -->

<!-- BEGIN MapZ Section-->
<div class="mapz-section">
  <div class="container">
	<div class="row">
	  <div class="col-md-12">
		<h3 class="section-title">サービスメニュー</h3>
		<!-- BEGIN MapZ Wrap-->
		<div class="mapz-wrap">                                     
		  <img data-src-base='${imageUrl}/' data-src='<992:mapz_o.jpg,>991:mapz.png'> 
		  <!-- BEGIN MapZ Mmenu Topleft-->
		  <nav class="mmenu topleft">
			<h3 class="title"><span class="mmenu-toggle">サービス利用登録</span></h3>
			<ul>
			  <li>医療機関の皆様</li>
			  <li>患者の皆様</li>
			  <li>関連企業のみなさま</li>
			</ul>
		  </nav><!-- END MapZ Mmenu Topleft-->
		  <!-- END MapZ Mmenu Topright-->
		  <nav class="mmenu topright">
			<h3 class="title"><span class="mmenu-toggle">医療機関の皆様へ</span></h3>
			<ul>
			  <li>機能紹介</li>
			  <li>導入方法・手順</li>
			  <li>使い方　マニュアル</li>
			  <li>周辺接続機器紹介</li>
			</ul>
		  </nav><!-- END MapZ Mmenu Topright-->
		  <!-- BEGIN MapZ Mmenu BottomLeft-->
		  <nav class="mmenu bottomleft">
			<h3 class="title"><span class="mmenu-toggle">関連企業の皆様へ</span></h3>
			<ul>
			  <li>サービスのご紹介</li>
			  <li>パートナー様募集</li>                     
			</ul>
		  </nav><!-- END MapZ Mmenu Bottomleft-->
		  <!-- BEGIN MapZ Mmenu BottomRight-->
		  <nav class="mmenu bottomright">
			<h3 class="title"><span class="mmenu-toggle">患者様サービス</span></h3>
			<ul>
			  <li>使い方</li>
			  <li>メニュー</li>                     
			</ul>
		  </nav><!-- END MapZ Mmenu BottomRight-->              
		</div> <!-- END MapZ Wrap -->               
	  </div>
	</div>
  </div>
</div><!-- END MapZ Wrapper-->
<!-- BEGIN Parter Section-->
<div class="partner-section">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="partner-box clearfix">
          <div class="logo-wrap">
            <img src="assets/img/nci_logo.jpg" alt="" alt="NCI">
          </div>
          <div class="text-wrap">
            <div class="text">エヌシーアイ株式会社（リンク：<a href="http://www.nisshoci.co.jp/service/zetacloud/" >http://www.nisshoci.co.jp/service/zetacloud/</a>）が提供する<br>
            					3省4ガイドラインを満足するセキュアかつ冗長性のあるクラウドサーバを利用しております。
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- END Parter Section-->