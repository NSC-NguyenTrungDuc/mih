package nta.med.service.ihis.handler.phys;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.phy.Phy8002;
import nta.med.core.domain.phy.Phy8003;
import nta.med.core.domain.phy.Phy8004;
import nta.med.core.domain.scan.Scan001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.phy.Phy8002Repository;
import nta.med.data.dao.medi.phy.Phy8003Repository;
import nta.med.data.dao.medi.phy.Phy8004Repository;
import nta.med.data.dao.medi.scan.Scan001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo;
import nta.med.service.ihis.proto.PhysModelProto.PHY8002U01GrdPHY8003LisItemInfo;
import nta.med.service.ihis.proto.PhysModelProto.PHY8002U01GrdPHY8004LisItemInfo;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01SaveLayoutRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01SaveLayoutResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01SaveLayoutHandler 
	extends ScreenHandler<PhysServiceProto.PHY8002U01SaveLayoutRequest, PhysServiceProto.PHY8002U01SaveLayoutResponse> {                     
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	@Resource                                                                                                       
	private Phy8002Repository phy8002Repository;       
	@Resource                                                                                                       
	private Phy8003Repository phy8003Repository;      
	@Resource                                                                                                       
	private Phy8004Repository phy8004Repository;      
	@Resource                                                                                                       
	private Scan001Repository scan001Repository;                                                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	@Resource                                                                                                       
	private Inp1001Repository inp1001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public PHY8002U01SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U01SaveLayoutRequest request) throws Exception {                                                                 
  	   	PhysServiceProto.PHY8002U01SaveLayoutResponse.Builder response = PhysServiceProto.PHY8002U01SaveLayoutResponse.newBuilder();
  		String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		boolean result8002 = false;
		boolean result8003 = false;
		boolean result8004 = false;
		
		// Caller_id = 2

		if(CollectionUtils.isEmpty(request.getInput8003List())){
			result8003 = true;
		}else{
			for(PHY8002U01GrdPHY8003LisItemInfo  item : request.getInput8003List()){
				result8003 = save8003(item, request, hospCode);	
				if(!result8003){
					response.setResult8003(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		
		// Caller_id = 3
		if(CollectionUtils.isEmpty(request.getInput8004List())){
			result8004 = true;
		}else{
			for(PHY8002U01GrdPHY8004LisItemInfo item : request.getInput8004List()){
				String pkChk = commonRepository.getNextVal("PHY8004_SEQ");
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					result8004 = insert8004(item, request.getUserId(), pkChk, hospCode);
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(!StringUtils.isEmpty(request.getCopyPkocskey())){
						result8004 = insert8004(item, request.getUserId(), pkChk, hospCode);
					}else{
						response.setMsgCase3("error");
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(phy8004Repository.deletePhy8002U018004(hospCode, CommonUtils.parseDouble(item.getPkPhySyougai()))>0){
						result8004 = true;
					}
				}
				if(!result8004){
					response.setResult8004(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		
		// Caller_id = 1
		if(CollectionUtils.isEmpty(request.getInput8002List())){
			result8002 = true;
		}else{
			for(PHY8002U01GrdPHY8002LisItemInfo item : request.getInput8002List()){
				PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder info = PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				// SET PHY8002 Info
				if(CommonUtils.parseInteger(request.getLeaveCnt())>0 || !item.getRowState().equalsIgnoreCase(DataRowState.UNCHANGED.getValue())){
					 info = setPHY8002Info(info, request.getBunho(), request.getIoKubun(), hospCode, language);
				}
				response.addSetPHY8002Info(info);
				//get pkphy
				String pkphy = item.getPkphy8002();
				if(StringUtils.isEmpty(pkphy)){
					pkphy = commonRepository.getNextVal("PHY8002_SEQ");
				}
				response.setPkPhy8002(pkphy);
				// save grd
				result8002 = save8002(request, info,
						pkphy, hospCode); 
				if(!(result8002)){
					response.setResult8002(false);
					throw new ExecutionException(response.build());
				}
			}
		}
				
		response.setResult8002(result8002);
		response.setResult8003(result8003);
		response.setResult8004(result8004);
		return response.build();
	}


	private boolean save8002(PhysServiceProto.PHY8002U01SaveLayoutRequest request,
			PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder info,
			String pkphy, String hospCode) throws ParseException {
		boolean save = false;
		boolean save8002 = false;
		boolean saveScan001 = false;
		String sinryouka = info.getSinryouka();
		String sindanisi = info.getSindanisi();
		String tantoui = info.getTantoui();
		if(info.getRowState().equalsIgnoreCase(DataRowState.UNCHANGED.getValue())){
			save = true;
		}else if(info.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
			if(!request.getUserGubun().equals("Doctor")){
				 sinryouka = request.getApproveDoctorGwa();
				 sindanisi = request.getApproveDoctorId();
				 tantoui = request.getApproveDoctorId();
			}
			// save image
			saveScan001 = insertScan001(info, request.getUserId(), request.getBunho(), hospCode);
			save8002 = insertPhy8002(info, request.getUserId(), pkphy, sinryouka, sindanisi, tantoui, request.getIoKubun(), hospCode);
		}else if(info.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
			if(!StringUtils.isEmpty(request.getCopyPkocskey())){
				//save image
				saveScan001 = insertScan001(info, request.getUserId(), request.getBunho(), hospCode);
				save8002 = insertPhy8002(info, request.getUserId(), pkphy, sinryouka, sindanisi, tantoui, request.getIoKubun(), hospCode);
			}else{
				//save image
				saveScan001 = insertScan001(info, request.getUserId(), request.getBunho(), hospCode);
				save8002 = updatePhy8002(info, request.getUserId(), pkphy, request.getIoKubun(), hospCode);
			}
		}
		if(saveScan001 && save8002){
			save = true;
		}
		return save;
	}       
	
	
	private PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder setPHY8002Info(PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder info, String bunho, String ioGubun, String hospCode, String language){
		String pkScan001 = commonRepository.getNextVal("SCAN001_SEQ");
		if(StringUtils.isEmpty(pkScan001)){
			pkScan001 = "1";
		}
		
		SimpleDateFormat format = new SimpleDateFormat(DateUtil.PATTERN_YYMMDD_BLANK);
		
		String iraiDate = info.getIraiDate();
		if(!StringUtils.isEmpty(iraiDate)){
			iraiDate = format.format(new Date());
		}
		
		String pathNm = ocs0132Repository.getCodeNameByCodeAndCodeType(hospCode, language, "RESULT_PATH", "PATH").get(0);
		// String pathNm = config.getIhisImageSavePath();
		String path = pathNm +"/REHA/REHA/"+iraiDate.toString().substring(0, 4)+"/"+iraiDate.toString()+"/";
		String name = bunho+"."+iraiDate.toString().replace("/", "")+"."+pkScan001 +".JPG";
	//	LOGGER.info("pathNm :"+config.getVertxClusterHost());
		if(ioGubun.equalsIgnoreCase("I")){
			String jaewonHodong = inp1001Repository.callFnInpLoadJaewonHoDong(hospCode, bunho);
			if(!StringUtils.isEmpty(jaewonHodong)){
				String str[] = jaewonHodong.split("-");
				if(!StringUtils.isEmpty(str[0]) && !StringUtils.isEmpty(str[1])){
					info.setByoutouCode(str[0]);
					info.setByousituCode(str[1]);
				}
			}
			
			String nyuuinnbi = inp1001Repository.callFnInpLoadLastIpwonDate(hospCode, bunho);
			if(!StringUtils.isEmpty(nyuuinnbi)){
				info.setNyuuinnbi(nyuuinnbi);
			}
		}
		
		// SET INFO
		info.setImagePath(path);
		info.setImage(name);
		info.setImageSeq(pkScan001);
		info.setYoinStartDate(info.getYoinStartDate().replace("-", "/"));
		info.setYoinSindanDate(info.getYoinSindanDate().replace("-", "/"));
		return info;
	}
	
	// save 8003
	private boolean save8003(PHY8002U01GrdPHY8003LisItemInfo  item, PhysServiceProto.PHY8002U01SaveLayoutRequest request, String hospCode){
		boolean save = false;
		String pkChk = commonRepository.getNextVal("PHY8002_SEQ");
		if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue()) ||
				(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue()) && !StringUtils.isEmpty(request.getCopyPkocskey()))){
			save = insertPhy8003(item, request.getUserId(), pkChk, hospCode);
		}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue()) && StringUtils.isEmpty(request.getCopyPkocskey())){
			save = update8003(item, request.getUserId());
		}else if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
			if(phy8003Repository.deletePhy8002U01Phy8003(hospCode, item.getPkPhySyoubyou())>0){
				save = true;
			}
		}
		return save;
	}
	
	
	private boolean insertPhy8002(PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder item, String userId, String pkphy, String sinryouka,
			String sindanisi, String tantoui, String ioKubun, String hospCode){
		Phy8002 phy8002 = new Phy8002();
		phy8002.setSysDate(new Date());
		phy8002.setUserId(userId);
		phy8002.setHospCode(hospCode);
		phy8002.setPkphy8002(CommonUtils.parseDouble(pkphy));
		phy8002.setFkOcs(CommonUtils.parseDouble(item.getFkOcs()));
		phy8002.setIoKubun(ioKubun);
		phy8002.setIraiDate(item.getIraiDate());
		phy8002.setKanjaNo(item.getKanjaNo());
		phy8002.setSinryouka(sinryouka);
		phy8002.setSindanisi(sindanisi);
		phy8002.setTantoui(tantoui);
		phy8002.setNyuuinnbi(item.getNyuuinnbi());
		phy8002.setByoutouCode(item.getByoutouCode());
		phy8002.setByousituCode(item.getByousituCode());
		phy8002.setKaisibi(DateUtil.toDate(item.getKaisibi(), DateUtil.PATTERN_YYMMDD));
		phy8002.setNissuu(CommonUtils.parseDouble(item.getNissuu()));
		phy8002.setKoumokuCode(item.getKoumokuCode());
		phy8002.setPt1(item.getPt1());
		phy8002.setPt2(item.getPt2());
		phy8002.setPt3(item.getPt3());
		phy8002.setPt4(item.getPt4());
		phy8002.setPt5(item.getPt5());
		phy8002.setPt6(item.getPt6());
		phy8002.setPt7(item.getPt7());
		phy8002.setPt8(item.getPt8());
		phy8002.setPt9(item.getPt9());
		phy8002.setPt10(item.getPt10());
		phy8002.setOt1(item.getOt1());
		phy8002.setOt2(item.getOt2());
		phy8002.setOt3(item.getOt3());
		phy8002.setOt4(item.getOt4());
		phy8002.setOt5(item.getOt5());
		phy8002.setOt6(item.getOt6());
		phy8002.setOt7(item.getOt7());
		phy8002.setOt8(item.getOt8());
		phy8002.setOt9(item.getOt9());
		phy8002.setOt10(item.getOt10());
		phy8002.setSt1(item.getSt1());
		phy8002.setSt2(item.getSt2());
		phy8002.setSt3(item.getSt3());
		phy8002.setSt4(item.getSt4());
		phy8002.setSt5(item.getSt5());
		phy8002.setSt6(item.getSt6());
		phy8002.setSt7(item.getSt7());
		phy8002.setSt8(item.getSt8());
		phy8002.setSt9(item.getSt9());
		phy8002.setSt10(item.getSt10());
		phy8002.setObjective(item.getObjective());
		phy8002.setConsultComment(item.getConsultComment());
		phy8002.setGenbyoureki(item.getGenbyoureki());
		phy8002.setComplications(item.getComplications());
		phy8002.setTaboo(item.getTaboo());
		phy8002.setStopKijyun(item.getStopKijyun());
		phy8002.setFrequency(item.getFrequency());
		phy8002.setInfectious(item.getInfectious());
		phy8002.setKioureki(item.getKioureki());
		phy8002.setSyoriFlag(item.getSyoriFlag());
		phy8002.setPtFlag(item.getPtFlag());
		phy8002.setOtFlag(item.getOtFlag());
		phy8002.setStFlag(item.getStFlag());
		phy8002.setSyujyutubi(DateUtil.toDate(item.getSyujyutubi(), DateUtil.PATTERN_YYMMDD));
		phy8002.setKyuseizouakubi(DateUtil.toDate(item.getKyuseizouakubi(), DateUtil.PATTERN_YYMMDD));
		phy8002.setDisuseGasyou(item.getDisuseGasyou());
		phy8002.setDisuseAdl(item.getDisuseAdl());
		phy8002.setDisuseKainyu(item.getDisuseKainyu());
		phy8002.setDisuseKaizen(item.getDisuseKaizen());
		phy8002.setDisuseContents(item.getDisuseContents());
		phy8002.setIraiKubun(item.getIraiKubun());
		phy8002.setDisuseFimbi(CommonUtils.parseDouble(item.getDisuseFimbi()));
		phy8002.setBuFlag(item.getBuFlag());
		phy8002.setYoinStartDate(DateUtil.toDate(item.getYoinStartDate(), DateUtil.PATTERN_YYMMDD));
		phy8002.setYoinSindanDate(DateUtil.toDate(item.getYoinSindanDate(), DateUtil.PATTERN_YYMMDD));
		phy8002.setKeFlag(item.getKeFlag());
		phy8002.setSu1(item.getSu1());
		phy8002.setSu21(item.getSu21());
		phy8002.setSu22(item.getSu22());
		phy8002.setSu23(item.getSu23());
		phy8002.setSu24(item.getSu24());
		phy8002.setSu31(item.getSu31());
		phy8002.setSu32(item.getSu32());
		phy8002.setSu41(item.getSu41());
		phy8002.setSu42(item.getSu42());
		phy8002.setSu43(item.getSu43());
		phy8002.setImage(item.getImage());
		phy8002.setImagePath(item.getImagePath());
		phy8002.setImageSeq(CommonUtils.parseDouble(item.getImageSeq()));
		phy8002.setCrTime(DateUtil.toDate(item.getCrTime(), DateUtil.PATTERN_YYMMDD));
		
		phy8002Repository.save(phy8002);
		return true;
	}
	
	private boolean insertScan001(PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder item, String userId, 
			String bunho, String hospCode) throws ParseException{
		Scan001 scan001 = new Scan001();
		scan001.setSysDate(new Date());
		scan001.setUpdId(userId);
		scan001.setUpdDate(new Date());
		scan001.setPkscan001(CommonUtils.parseDouble(item.getImageSeq()));
		scan001.setFkocs(CommonUtils.parseDouble(item.getFkOcs()));
		scan001.setSystem("REHA");
		scan001.setCrTime(new Date());
		scan001.setJundalPart("REHA");
		scan001.setBunho(bunho);
		scan001.setImagePath(item.getImagePath());
		scan001.setImage(item.getImage());
		scan001.setSeq(CommonUtils.parseDouble(item.getImageSeq()));
		scan001.setSysId(userId);
		scan001.setHospCode(hospCode);
		
		scan001Repository.save(scan001);
		return true;
	}
	
	private boolean updatePhy8002(PhysModelProto.PHY8002U01GrdPHY8002LisItemInfo.Builder item, String userId, String pkphy, String ioKubun, String hospCode){		
		if(phy8002Repository.updatePhy8002U01(
				CommonUtils.parseDouble(pkphy),
				userId,
				new Date(),
				item.getIraiDate(),
				DateUtil.toDate(item.getKaisibi(), DateUtil.PATTERN_YYMMDD),
				CommonUtils.parseDouble(item.getNissuu()),
				item.getSu1(),
				item.getSu21(),
				item.getSu22(),
				item.getSu23(),
				item.getSu24(),
				item.getSu31(),
				item.getSu32(),
				item.getSu41(),
				item.getSu42(),
				item.getSu43(),
				item.getPt1(),
				item.getPt2(),
				item.getPt3(),
				item.getPt4(),
				item.getPt5(),
				item.getPt6(),
				item.getPt7(),
				item.getPt8(),
				item.getPt9(),
				item.getPt10(),
				item.getOt1(),
				item.getOt2(),
				item.getOt3(),
				item.getOt4(),
				item.getOt5(),
				item.getOt6(),
				item.getOt7(),
				item.getOt8(),
				item.getOt9(),
				item.getOt10(),
				item.getSt1(),
				item.getSt2(),
				item.getSt3(),
				item.getSt4(),
				item.getSt5(),
				item.getSt6(),
				item.getSt7(),
				item.getSt8(),
				item.getSt9(),
				item.getSt10(),
				item.getObjective(),
				item.getConsultComment(),
				item.getGenbyoureki(),
				item.getComplications(),
				item.getTaboo(),
				item.getStopKijyun(),
				item.getFrequency(),
				item.getInfectious(),
				item.getKioureki(),
				item.getSyoriFlag(),
				item.getPtFlag(),
				item.getOtFlag(),
				item.getStFlag(),
				item.getBuFlag(),
				item.getKeFlag(),
				DateUtil.toDate(item.getSyujyutubi(), DateUtil.PATTERN_YYMMDD),
				DateUtil.toDate(item.getKyuseizouakubi(), DateUtil.PATTERN_YYMMDD),
				item.getDisuseGasyou(),
				item.getDisuseAdl(),
				item.getDisuseKainyu(),
				item.getDisuseKaizen(),
				item.getDisuseContents(),
				CommonUtils.parseDouble(item.getDisuseFimbi()),
				DateUtil.toDate(item.getYoinStartDate(), DateUtil.PATTERN_YYMMDD),
				DateUtil.toDate(item.getYoinSindanDate(), DateUtil.PATTERN_YYMMDD),
				item.getImage(),
				item.getImagePath(),
				CommonUtils.parseDouble(item.getImageSeq()),
				DateUtil.toDate(item.getCrTime(), DateUtil.PATTERN_YYMMDD),
				CommonUtils.parseDouble(item.getFkOcs()),
				hospCode,
				ioKubun)>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean insertPhy8003(PHY8002U01GrdPHY8003LisItemInfo item, String userId, String pkChk, String hospCode){
		Phy8003 phy8003 = new Phy8003();
		phy8003.setSysDate(new Date());
		phy8003.setUserId(userId);
		phy8003.setHospCode(hospCode);
		phy8003.setPkPhySyoubyou(CommonUtils.parseDouble(pkChk));
		phy8003.setFkOcsIrai(CommonUtils.parseDouble(item.getFkOcsIrai()));
		phy8003.setDataKubun("I");
		phy8003.setIoKubun(item.getIoKubun());
		phy8003.setIraiDate(item.getIraiDate());
		phy8003.setKanjaNo(item.getKanjaNo());
		phy8003.setSinryouka(item.getSinryouka());
		phy8003.setSyoubyoumeiCode(item.getSyoubyoumeiCode());
		phy8003.setPreModifier1(item.getPreModifier1());
		phy8003.setPreModifier2(item.getPreModifier2());
		phy8003.setPreModifier3(item.getPreModifier3());
		phy8003.setPreModifier4(item.getPreModifier4());
		phy8003.setPreModifier5(item.getPreModifier5());
		phy8003.setPreModifier6(item.getPreModifier6());
		phy8003.setPreModifier7(item.getPreModifier7());
		phy8003.setPreModifier8(item.getPreModifier8());
		phy8003.setPreModifier9(item.getPreModifier9());
		phy8003.setPreModifier10(item.getPreModifier10());
		phy8003.setPostModifier1(item.getPostModifier1());
		phy8003.setPostModifier2(item.getPostModifier2());
		phy8003.setPostModifier3(item.getPostModifier3());
		phy8003.setPostModifier4(item.getPostModifier4());
		phy8003.setPostModifier5(item.getPostModifier5());
		phy8003.setPostModifier6(item.getPostModifier6());
		phy8003.setPostModifier7(item.getPostModifier7());
		phy8003.setPostModifier8(item.getPostModifier8());
		phy8003.setPostModifier9(item.getPostModifier9());
		phy8003.setPostModifier10(item.getPostModifier10());
		phy8003.setHassyoubi(item.getHassyoubi());
		phy8003.setSindanbi(item.getSindanbi());
		phy8003.setPreModifierName(item.getPreModifierName());
		phy8003.setPostModifierName(item.getPostModifierName());
		phy8003.setSyoubyoumei(item.getSyoubyoumei());
		phy8003.setFkoutsang(CommonUtils.parseDouble(item.getFkoutsang()));
		phy8003Repository.save(phy8003);
		return true;
	}
	
	private boolean update8003(PHY8002U01GrdPHY8003LisItemInfo item, String userId){
		if(phy8003Repository.updatePhy8002U01Phy8003(
				userId,
				"U",
				item.getIoKubun(),
				item.getIraiDate(),
				item.getSyoubyoumeiCode(),
				item.getPreModifier1(),
				item.getPreModifier2(),
				item.getPreModifier3(),
				item.getPreModifier4(),
				item.getPreModifier5(),
				item.getPreModifier6(),
				item.getPreModifier7(),
				item.getPreModifier8(),
				item.getPreModifier9(),
				item.getPreModifier10(),
				item.getPostModifier1(),
				item.getPostModifier2(),
				item.getPostModifier3(),
				item.getPostModifier4(),
				item.getPostModifier5(),
				item.getPostModifier6(),
				item.getPostModifier7(),
				item.getPostModifier8(),
				item.getPostModifier9(),
				item.getPostModifier10(),
				item.getHassyoubi(),
				item.getSindanbi(),
				item.getPreModifierName(),
				item.getPostModifierName(),
				item.getSyoubyoumei(),
				item.getHospCode(),
				item.getPkPhySyoubyou())>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean insert8004(PHY8002U01GrdPHY8004LisItemInfo item , String userId, String pkChk, String hospCode){
		Phy8004 phy8004 = new Phy8004();
		phy8004.setSysDate(new Date());
		phy8004.setUserId(userId);
		phy8004.setUpdDate(DateUtil.toDate(item.getUpdDate(), DateUtil.PATTERN_YYMMDD));
		phy8004.setHospCode(hospCode);
		phy8004.setPkPhySyougai(CommonUtils.parseDouble(pkChk));
		phy8004.setDataKubun(item.getDataKubun());
		phy8004.setFkOcsIrai(CommonUtils.parseDouble(item.getFkOcsIrai()));
		phy8004.setSyougaiId(item.getSyougaiId());
		phy8004.setSyougaimei(item.getSyougaimei());
		phy8004.setKanjaNo(item.getKanjaNo());
		phy8004.setFkcht0113(CommonUtils.parseDouble(item.getFkcht0113()));
		phy8004Repository.save(phy8004);
		return true;
	}
}