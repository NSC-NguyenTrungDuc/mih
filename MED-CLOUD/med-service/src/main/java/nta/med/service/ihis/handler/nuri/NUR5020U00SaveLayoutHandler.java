package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur5020;
import nta.med.core.domain.nur.Nur5021;
import nta.med.core.domain.nur.Nur5023;
import nta.med.core.domain.nur.Nur5024;
import nta.med.core.domain.nur.Nur5025;
import nta.med.core.domain.nur.Nur5026;
import nta.med.core.domain.nur.Nur5027;
import nta.med.core.domain.nur.Nur5028;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur5020Repository;
import nta.med.data.dao.medi.nur.Nur5021Repository;
import nta.med.data.dao.medi.nur.Nur5023Repository;
import nta.med.data.dao.medi.nur.Nur5024Repository;
import nta.med.data.dao.medi.nur.Nur5025Repository;
import nta.med.data.dao.medi.nur.Nur5026Repository;
import nta.med.data.dao.medi.nur.Nur5027Repository;
import nta.med.data.dao.medi.nur.Nur5028Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR5020U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR5020U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur5020Repository nur5020Repository;

	@Resource
	private Nur5021Repository nur5021Repository;

	@Resource
	private Nur5023Repository nur5023Repository;
	
	@Resource
	private Nur5025Repository nur5025Repository;
	
	@Resource
	private Nur5027Repository nur5027Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Nur5024Repository nur5024Repository;
	
	@Resource
	private Nur5026Repository nur5026Repository;
	
	@Resource
	private Nur5028Repository nur5028Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);

		List<NuriModelProto.NUR5020U00layNur5020Info> laynur5020info = request.getLaynur5020InfoList();
		List<NuriModelProto.NUR5020U00grdGuhoGubunInfo> grdguhogubuninfo = request.getGrdguhogubuninfoList();
		List<NuriModelProto.NUR5020U00grdWoiInfo> grdwoiinfo = request.getGrdwoiinfoList();
		List<NuriModelProto.NUR5020U00grdCommentInfo> grdcommentinfo = request.getGrdcommentinfoList();
		List<NuriModelProto.NUR5020U00grdNURCntInfo> grdnurcntinfo = request.getGrdnurcntinfoList();
		List<NuriModelProto.NUR5020U00grdIpToiInfo> grdiptoiinfo = request.getGrdiptoiinfoList();
		List<NuriModelProto.NUR5020U00grdTransInfo> grdtransinfo = request.getGrdtransinfoList();
		List<NuriModelProto.NUR5020U00grdSusulInfo> grdsusulinfo = request.getGrdsusulinfoList();
		List<NuriModelProto.NUR5020U00grdWatchListInfo> grdwatchlistinfo = request.getGrdwatchlistinfoList();
		List<NuriModelProto.NUR5020U00grdGwaInfo> grdgwainfo = request.getGrdgwainfoList();
		List<NuriModelProto.NUR5020U00grdBedSoreInfo> grdbedsoreinfo = request.getGrdbedsoreinfoList();

		handleLaynur5020info(hospCode, userId, laynur5020info);

		handleGrdguhogubuninfo(hospCode, userId, grdguhogubuninfo);

		handleGrdwoiinfo(hospCode, userId, grdwoiinfo);

		handleGrdcommentinfo(hospCode, userId, grdcommentinfo);

		handleGrdnurcntinfo(hospCode, userId, grdnurcntinfo);

		handleGrdiptoiinfo(hospCode, userId, grdiptoiinfo);

		handlegrdtransinfo(hospCode, userId, grdtransinfo);

		handleGrdsusulinfo(hospCode, userId, grdsusulinfo);

		handleGrdwatchlistinfo(hospCode, userId, grdwatchlistinfo);

		handleGrdgwainfo(hospCode, userId, grdgwainfo);

		handleGrdbedsoreinfo(hospCode, userId, grdbedsoreinfo);

		response.setResult(true);
		return response.build();
	}

	private void handleLaynur5020info(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00layNur5020Info> laynur5020info) {
		Date sysDate = Calendar.getInstance().getTime();

		for (NuriModelProto.NUR5020U00layNur5020Info info : laynur5020info) {
			List<Nur5020> items = nur5020Repository.findByHospCodeNurWrdtHoDong(hospCode,
					DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong());

			if (CollectionUtils.isEmpty(items)) {
				Nur5020 nur5020 = new Nur5020();

				nur5020.setSysDate(sysDate);
				nur5020.setSysId(userId);
				nur5020.setUpdDate(sysDate);
				nur5020.setUpdId(userId);
				nur5020.setHospCode(hospCode);
				nur5020.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));
				nur5020.setHoDong(info.getHoDong());
				nur5020.setYesterdayCnt(CommonUtils.parseDouble(info.getYesterdayCnt()));
				nur5020.setIpwonCnt(CommonUtils.parseDouble(info.getIpwonCnt()));
				nur5020.setMoveInCnt(CommonUtils.parseDouble(info.getMoveInCnt()));
				nur5020.setToiwonCnt(CommonUtils.parseDouble(info.getToiwonCnt()));
				nur5020.setJaewonCnt(CommonUtils.parseDouble(info.getJaewonCnt()));
				nur5020.setMoveOutCnt(CommonUtils.parseDouble(info.getMoveOutCnt()));
				nur5020.setGamyum1Cnt(CommonUtils.parseDouble(info.getGamyum1Cnt()));
				nur5020.setGamyum2Cnt(CommonUtils.parseDouble(info.getGamyum2Cnt()));
				nur5020.setGamyum3Cnt(CommonUtils.parseDouble(info.getGamyum3Cnt()));
				nur5020.setGamyum4Cnt(CommonUtils.parseDouble(info.getGamyum4Cnt()));
				nur5020.setGamyum5Cnt(CommonUtils.parseDouble(info.getGamyum5Cnt()));
				nur5020.setGamyum6Cnt(CommonUtils.parseDouble(info.getGamyum6Cnt()));
				nur5020.setGamyum7Cnt(CommonUtils.parseDouble(info.getGamyum7Cnt()));
				nur5020.setGamyum8Cnt(CommonUtils.parseDouble(info.getGamyum8Cnt()));
				nur5020.setGamyum6Name(info.getGamyum6Name());
				nur5020.setGamyum7Name(info.getGamyum7Name());
				nur5020.setGamyum8Name(info.getGamyum8Name());
				nur5020.setYokchangNurse(info.getNurse());
				nur5020.setYokchangComment(info.getYokchangComment());

				nur5020Repository.save(nur5020);

			} else {
				Nur5020 nur5020 = items.get(0);
				nur5020.setUpdDate(sysDate);
				nur5020.setUpdId(userId);
				nur5020.setYesterdayCnt(CommonUtils.parseDouble(info.getYesterdayCnt()));
				nur5020.setIpwonCnt(CommonUtils.parseDouble(info.getIpwonCnt()));
				nur5020.setMoveInCnt(CommonUtils.parseDouble(info.getMoveInCnt()));
				nur5020.setToiwonCnt(CommonUtils.parseDouble(info.getToiwonCnt()));
				nur5020.setJaewonCnt(CommonUtils.parseDouble(info.getJaewonCnt()));
				nur5020.setMoveOutCnt(CommonUtils.parseDouble(info.getMoveOutCnt()));
				nur5020.setGamyum1Cnt(CommonUtils.parseDouble(info.getGamyum1Cnt()));
				nur5020.setGamyum2Cnt(CommonUtils.parseDouble(info.getGamyum2Cnt()));
				nur5020.setGamyum3Cnt(CommonUtils.parseDouble(info.getGamyum3Cnt()));
				nur5020.setGamyum4Cnt(CommonUtils.parseDouble(info.getGamyum4Cnt()));
				nur5020.setGamyum5Cnt(CommonUtils.parseDouble(info.getGamyum5Cnt()));
				nur5020.setGamyum6Cnt(CommonUtils.parseDouble(info.getGamyum6Cnt()));
				nur5020.setGamyum7Cnt(CommonUtils.parseDouble(info.getGamyum7Cnt()));
				nur5020.setGamyum8Cnt(CommonUtils.parseDouble(info.getGamyum8Cnt()));
				nur5020.setYokchangNurse(info.getNurse());
				nur5020.setYokchangComment(info.getYokchangComment());

				nur5020Repository.save(nur5020);
			}
		}
	}

	private void handleGrdguhogubuninfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdGuhoGubunInfo> grdguhogubuninfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdGuhoGubunInfo info : grdguhogubuninfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur5021 nur5021 = new Nur5021();
				
				nur5021.setSysDate(sysDate);                                                        
				nur5021.setSysId(userId);                                                           
				nur5021.setUpdDate(sysDate);                                                        
				nur5021.setUpdId(userId);                                                           
				nur5021.setHospCode(hospCode);                                                      
				nur5021.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));    
				nur5021.setHoDong(info.getHoDong());                                                
				nur5021.setStair(info.getStair());
				nur5021.setStairName(info.getStairName());
				nur5021.setStairTotalCnt(CommonUtils.parseDouble(info.getStairTotalCnt()));
				nur5021.setDansongCnt(CommonUtils.parseDouble(info.getDansongCnt()));
				nur5021.setHosongCnt(CommonUtils.parseDouble(info.getHosongCnt()));
				nur5021.setDokboCnt(CommonUtils.parseDouble(info.getDokboCnt()));
				
				nur5021Repository.save(nur5021);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5021> items = nur5021Repository.findByHospCodeNurWrdtHoDong(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong());
				if(!CollectionUtils.isEmpty(items)){
					Nur5021 nur5021 = items.get(0);
					nur5021.setStair(info.getStair());
					nur5021.setStairName(info.getStairName());
					nur5021.setStairTotalCnt(CommonUtils.parseDouble(info.getStairTotalCnt()));
					nur5021.setDansongCnt(CommonUtils.parseDouble(info.getDansongCnt()));
					nur5021.setHosongCnt(CommonUtils.parseDouble(info.getHosongCnt()));
					nur5021.setDokboCnt(CommonUtils.parseDouble(info.getDokboCnt()));
					
					nur5021Repository.save(nur5021);
				}
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5021> items = nur5021Repository.findByHospCodeNurWrdtHoDong(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong());
				if(!CollectionUtils.isEmpty(items)){
					Nur5021 nur5021 = items.get(0);
					nur5021Repository.delete(nur5021);
				}
			}
		}
	}

	private void handleGrdwoiinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdWoiInfo> grdwoiinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdWoiInfo info : grdwoiinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				String pk = commonRepository.getNextVal("NUR5023_SEQ");
				
				Nur5023 nur5023 = new Nur5023();
				
				nur5023.setSysDate(sysDate);                                                     
				nur5023.setSysId(userId);                              
				nur5023.setPknur5023(CommonUtils.parseDouble(pk));
				nur5023.setUpdDate(sysDate);                                                     
				nur5023.setUpdId(userId);                                                        
				nur5023.setHospCode(hospCode);                                                   
				nur5023.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD)); 
				nur5023.setHoDong(info.getHoDong());                                             
				nur5023.setHoCode(info.getHoCode());
				nur5023.setGubun("1");
				nur5023.setDetailGubun(info.getGubun());
				nur5023.setBunho(info.getBunho());
				nur5023.setDate1(DateUtil.toDate(info.getDate1(), DateUtil.PATTERN_YYMMDD));
				nur5023.setTime1(info.getTime1());
				nur5023.setDate2(DateUtil.toDate(info.getDate2(), DateUtil.PATTERN_YYMMDD));
				nur5023.setTime2(info.getTime2());
				nur5023.setBigo(info.getBigo());
				
				nur5023Repository.save(nur5023);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023.setHoCode(info.getHoCode());
					nur5023.setDetailGubun(info.getGubun());
					nur5023.setDate1(DateUtil.toDate(info.getDate1(), DateUtil.PATTERN_YYMMDD));
					nur5023.setTime1(info.getTime1());
					nur5023.setDate2(DateUtil.toDate(info.getDate2(), DateUtil.PATTERN_YYMMDD));
					nur5023.setTime2(info.getTime2());
					nur5023.setBigo(info.getBigo());
					
					nur5023Repository.save(nur5023);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023Repository.delete(nur5023);
				}
			}
		}
	}

	private void handleGrdcommentinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdCommentInfo> grdcommentinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdCommentInfo info : grdcommentinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Double seq = nur5025Repository.getMaxSeq(hospCode, info.getHoDong(),
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));
				seq = seq == null ? 1.0 : seq + 1.0;
				
				Nur5025 nur5025 = new Nur5025();
				nur5025.setSysDate(sysDate);   
				nur5025.setSysId(userId);      
				nur5025.setUpdDate(sysDate);   
				nur5025.setUpdId(userId);      
				nur5025.setHospCode(hospCode); 
				nur5025.setHoDong(info.getHoDong());
				nur5025.setCommentDate(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));
				nur5025.setRemark(info.getComment());
				nur5025.setSeq(seq);
				
				nur5025Repository.save(nur5025);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5025> items = nur5025Repository.findByHospCodeHoDongCommentDateSeq(hospCode, info.getHoDong(),
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD),
						CommonUtils.parseDouble(info.getSeq()));
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5025 nur5025 = items.get(0);
					nur5025.setUpdDate(sysDate);   
					nur5025.setUpdId(userId);   
					nur5025.setRemark(info.getComment());
					
					nur5025Repository.save(nur5025);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5025> items = nur5025Repository.findByHospCodeHoDongCommentDateSeq(hospCode, info.getHoDong(),
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD),
						CommonUtils.parseDouble(info.getSeq()));
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5025 nur5025 = items.get(0);
					nur5025Repository.delete(nur5025);
				}
			}
		}
	}

	private void handleGrdnurcntinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdNURCntInfo> grdnurcntinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdNURCntInfo info : grdnurcntinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState()) 
					|| DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				
				List<Nur5027> items = nur5027Repository.findByHospCodeNurWrdtHoDong(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getNurGrade());
				if(CollectionUtils.isEmpty(items)){
					Nur5027 nur5027 = new Nur5027();
					nur5027.setSysDate(sysDate);        
					nur5027.setSysId(userId);           
					nur5027.setUpdDate(sysDate);        
					nur5027.setUpdId(userId);           
					nur5027.setHospCode(hospCode);      
					nur5027.setHoDong(info.getHoDong());
					nur5027.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));
					nur5027.setNurGrade(info.getNurGrade());
					nur5027.setDawnCnt(CommonUtils.parseDouble(info.getDawnCnt()));
					nur5027.setNightCnt(CommonUtils.parseDouble(info.getNightCnt()));
					nur5027.setHoliCnt(CommonUtils.parseDouble(info.getHoliCnt()));
					nur5027.setPayCnt(CommonUtils.parseDouble(info.getPayCnt()));
					nur5027.setChildcareCnt(CommonUtils.parseDouble(info.getChildcareCnt()));
					nur5027.setSpecialCnt(CommonUtils.parseDouble(info.getSpecialCnt()));
					nur5027.setStudyCnt(CommonUtils.parseDouble(info.getStudyCnt()));
					nur5027.setAbsenceCnt(CommonUtils.parseDouble(info.getAbsenceCnt()));
					
					nur5027Repository.save(nur5027);
				}
				else {
					Nur5027 nur5027 = items.get(0);
					
					nur5027.setUpdDate(sysDate);        
					nur5027.setUpdId(userId);              
					nur5027.setDawnCnt(CommonUtils.parseDouble(info.getDawnCnt()));
					nur5027.setNightCnt(CommonUtils.parseDouble(info.getNightCnt()));
					nur5027.setHoliCnt(CommonUtils.parseDouble(info.getHoliCnt()));
					nur5027.setPayCnt(CommonUtils.parseDouble(info.getPayCnt()));
					nur5027.setChildcareCnt(CommonUtils.parseDouble(info.getChildcareCnt()));
					nur5027.setSpecialCnt(CommonUtils.parseDouble(info.getSpecialCnt()));
					nur5027.setStudyCnt(CommonUtils.parseDouble(info.getStudyCnt()));
					nur5027.setAbsenceCnt(CommonUtils.parseDouble(info.getAbsenceCnt()));
					
					nur5027Repository.save(nur5027);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5027> items = nur5027Repository.findByHospCodeNurWrdtHoDong(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getNurGrade());
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5027 nur5027 = items.get(0);
					nur5027Repository.save(nur5027);
				}
			}
		}
	}

	private void handleGrdiptoiinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdIpToiInfo> grdiptoiinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdIpToiInfo info : grdiptoiinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				String pk = commonRepository.getNextVal("NUR5023_SEQ");
				
				Nur5023 nur5023 = new Nur5023();
				
				nur5023.setSysDate(sysDate);                                                     
				nur5023.setSysId(userId);    
				nur5023.setPknur5023(CommonUtils.parseDouble(pk));
				nur5023.setUpdDate(sysDate);                                                     
				nur5023.setUpdId(userId);                                                        
				nur5023.setHospCode(hospCode);                                                   
				nur5023.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD)); 
				nur5023.setHoDong(info.getHoDong());                                             
				nur5023.setHoCode(info.getHoCode());
				nur5023.setGubun("2");
				nur5023.setDetailGubun(info.getGubun());
				nur5023.setBunho(info.getBunho());
				nur5023.setGwa(info.getGwa());
				nur5023.setSang(info.getSang());
				nur5023.setBigo(info.getBigo());
				
				nur5023Repository.save(nur5023);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023.setBunho(info.getBunho());
					nur5023.setDetailGubun(info.getGubun());
					nur5023.setGwa(info.getGwa());
					nur5023.setSang(info.getSang());
					nur5023.setBigo(info.getBigo());
					
					nur5023Repository.save(nur5023);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023Repository.delete(nur5023);
				}
			}
		}
	}

	private void handlegrdtransinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdTransInfo> grdtransinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdTransInfo info : grdtransinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				String pk = commonRepository.getNextVal("NUR5023_SEQ");
				Nur5023 nur5023 = new Nur5023();
				
				nur5023.setSysDate(sysDate);                                                     
				nur5023.setSysId(userId);    
				nur5023.setPknur5023(CommonUtils.parseDouble(pk));
				nur5023.setUpdDate(sysDate);                                                     
				nur5023.setUpdId(userId);                                                        
				nur5023.setHospCode(hospCode);                                                   
				nur5023.setGubun("3");
				nur5023.setDetailGubun(info.getGubun());
				nur5023.setBunho(info.getBunho());
				nur5023.setFromGwa(info.getFromGwa());
				nur5023.setToGwa(info.getToGwa());
				nur5023.setFromHoCode(info.getFromHoCode());
				nur5023.setToHoCode(info.getToHoCode());
				
				nur5023Repository.save(nur5023);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023.setBunho(info.getBunho());
					nur5023.setDetailGubun(info.getGubun());
					nur5023.setFromGwa(info.getFromGwa());
					nur5023.setToGwa(info.getToGwa());
					nur5023.setFromHoCode(info.getFromHoCode());
					nur5023.setToHoCode(info.getToHoCode());
					
					nur5023Repository.save(nur5023);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5023> items = nur5023Repository.findByHospCodePknur5023(hospCode,
						CommonUtils.parseDouble(info.getPknur5023()));
				if(!CollectionUtils.isEmpty(items)){
					Nur5023 nur5023 = items.get(0);
					nur5023Repository.delete(nur5023);
				}
			}
		}
	}

	private void handleGrdsusulinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdSusulInfo> grdsusulinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdSusulInfo info : grdsusulinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur5024 nur5024 = new Nur5024();
				nur5024.setSysDate(sysDate);                                                       
				nur5024.setSysId(userId);                                                          
				nur5024.setUpdDate(sysDate);                                                       
				nur5024.setUpdId(userId);                                                          
				nur5024.setHospCode(hospCode);                                                     
				nur5024.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));   
				nur5024.setHoDong(info.getHoDong());                                               
				nur5024.setHoCode(info.getHoCode());
				nur5024.setGubun("1");
				nur5024.setDetailGubun("1");
				nur5024.setBunho(info.getBunho());
				nur5024.setSang(info.getSang());
				nur5024.setSulsik(info.getSusul());
				nur5024.setGwa(info.getGwa());
				nur5024.setComment1(info.getState1());
				nur5024.setComment2(info.getState2());
				nur5024.setComment3(info.getState3());
				
				nur5024Repository.save(nur5024);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5024> items = nur5024Repository.findByHospCodeNurWrdtHoDongBunho(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getBunho());
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5024 nur5024 = items.get(0);
					
					nur5024.setUpdDate(sysDate);                                                       
					nur5024.setUpdId(userId);                                                                                                               
					nur5024.setHoCode(info.getHoCode());
					nur5024.setSang(info.getSang());
					nur5024.setSulsik(info.getSusul());
					nur5024.setGwa(info.getGwa());
					nur5024.setComment1(info.getState1());
					nur5024.setComment2(info.getState2());
					nur5024.setComment3(info.getState3());
					
					nur5024Repository.save(nur5024);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5024> items = nur5024Repository.findByHospCodeNurWrdtHoDongBunho(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getBunho());
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5024 nur5024 = items.get(0);
					nur5024Repository.delete(nur5024);
				}
			}
		}
	}

	private void handleGrdwatchlistinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdWatchListInfo> grdwatchlistinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdWatchListInfo info : grdwatchlistinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur5024 nur5024 = new Nur5024();
				nur5024.setSysDate(sysDate);                                                       
				nur5024.setSysId(userId);                                                          
				nur5024.setUpdDate(sysDate);                                                       
				nur5024.setUpdId(userId);                                                          
				nur5024.setHospCode(hospCode);                                                     
				nur5024.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD));   
				nur5024.setHoDong(info.getHoDong());                                               
				nur5024.setHoCode(info.getHoCode());
				nur5024.setGubun("2");
				nur5024.setDetailGubun(info.getGubun());
				nur5024.setBunho(info.getBunho());
				nur5024.setSang(info.getSang());
				nur5024.setGwa(info.getGwa());
				nur5024.setComment1(info.getState1());
				nur5024.setComment2(info.getState2());
				nur5024.setComment3(info.getState3());
				
				nur5024Repository.save(nur5024);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				List<Nur5024> items = nur5024Repository.findByHospCodeNurWrdtHoDongBunhoDetailGubun(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getBunho(), "2");
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5024 nur5024 = items.get(0);
					
					nur5024.setUpdDate(sysDate);                                                       
					nur5024.setUpdId(userId);                                                                                                               
					nur5024.setHoCode(info.getHoCode());
					nur5024.setSang(info.getSang());
					nur5024.setGwa(info.getGwa());
					nur5024.setComment1(info.getState1());
					nur5024.setComment2(info.getState2());
					nur5024.setComment3(info.getState3());
					
					nur5024Repository.save(nur5024);
				}
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				List<Nur5024> items = nur5024Repository.findByHospCodeNurWrdtHoDongBunho(hospCode,
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getHoDong(), info.getBunho());
				
				if(!CollectionUtils.isEmpty(items)){
					Nur5024 nur5024 = items.get(0);
					nur5024Repository.delete(nur5024);
				}
			}
		}
	}

	private void handleGrdgwainfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdGwaInfo> grdgwainfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdGwaInfo info : grdgwainfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur5026 nur5026 = new Nur5026();
				nur5026.setSysDate(sysDate);                                                     
				nur5026.setSysId(userId);                                                        
				nur5026.setUpdDate(sysDate);                                                     
				nur5026.setUpdId(userId);                                                        
				nur5026.setHospCode(hospCode);                                                   
				nur5026.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD)); 
				nur5026.setHoDong(info.getHoDong());                                             
				nur5026.setGwa(info.getGwa());
				nur5026.setGwaName(info.getGwaName());
				nur5026.setPaCnt(CommonUtils.parseDouble(info.getPaCnt()));
				
				nur5026Repository.save(nur5026);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				nur5026Repository.updByHospCodeHoDongNurWrdtGwa(userId, CommonUtils.parseDouble(info.getPaCnt()),
						hospCode, info.getHoDong(), DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getGwa());
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				nur5026Repository.deleteByHospCodeHoDongNurWrdtGwa(hospCode, info.getHoDong(),
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getGwa());
			}
		}
	}

	private void handleGrdbedsoreinfo(String hospCode, String userId,
			List<NuriModelProto.NUR5020U00grdBedSoreInfo> grdbedsoreinfo) {
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR5020U00grdBedSoreInfo info : grdbedsoreinfo) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur5028 nur5028 = new Nur5028();
				nur5028.setSysDate(sysDate);                                                     
				nur5028.setSysId(userId);                                                        
				nur5028.setUpdDate(sysDate);                                                     
				nur5028.setUpdId(userId);                                                        
				nur5028.setHospCode(hospCode);                                                   
				nur5028.setNurWrdt(DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD)); 
				nur5028.setHoDong(info.getHoDong());                                             
				nur5028.setHoCode(info.getHoCode());
				nur5028.setBunho(info.getBunho());
				nur5028.setFromDate(DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
				nur5028.setBuwi(info.getBuwi());
				
				nur5028Repository.save(nur5028);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				nur5028Repository.updByHospCodeHoDongNurWrdtBunhoFromDate(userId, info.getBuwi(), hospCode,
						info.getHoDong(), DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getBunho(),
						DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
				
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				nur5028Repository.deleteByHospCodeHoDongNurWrdtBunhoFromDate(hospCode, info.getHoDong(),
						DateUtil.toDate(info.getNurWrdt(), DateUtil.PATTERN_YYMMDD), info.getBunho(),
						DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}
}
