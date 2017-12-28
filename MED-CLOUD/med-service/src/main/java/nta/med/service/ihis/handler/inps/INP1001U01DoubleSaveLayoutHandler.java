package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inp.Inp1001;
import nta.med.core.domain.inp.Inp1002;
import nta.med.core.domain.inp.Inp1008;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.inp.Inp1008Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.InpsModelProto.INP1001U01DoubleGrdINP1008Info;
import nta.med.service.ihis.proto.InpsModelProto.INP1001U01DoubleLayINP1001Info;
import nta.med.service.ihis.proto.InpsModelProto.INP1001U01DoubleLayINP1002Info;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                        
@Scope("prototype")
public class INP1001U01DoubleSaveLayoutHandler extends ScreenHandler<InpsServiceProto.INP1001U01DoubleSaveLayoutRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(INP1001U01DoubleSaveLayoutHandler.class);
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Bas0210Repository bas0210Repository;
	
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Resource
	private Out0105Repository out0105Repository;
	
	@Resource
	private Inp1008Repository inp1008Repository;

	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, InpsServiceProto.INP1001U01DoubleSaveLayoutRequest request) throws Exception{
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String retval = "";
		String sPkinp1001 = "";
		String mPKINP1002 = "";
		
		if(!CollectionUtils.isEmpty(request.getLayInp1001List())){
			for(INP1001U01DoubleLayINP1001Info item : request.getLayInp1001List()){
				Date ipwonDate = DateUtil.toDate(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD);	
				Date gisanIpwonDate = DateUtil.toDate(item.getGisanIpwonDate(), DateUtil.PATTERN_YYMMDD);
				String bunho = item.getBunho();
				
				if(ipwonDate.compareTo(gisanIpwonDate) < 0){
					LOGGER.info(String.format("Error message = 3639, hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg("3639");
					throw new ExecutionException(response.build());
				}
				
				retval = inp1001Repository.inpIsValidGisanDate(hospCode, gisanIpwonDate, gisanIpwonDate, bunho);
				
				if((retval == null)||(retval != null && !retval.equals("Y"))){
					LOGGER.info(String.format("Error message = 3640, hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg("3640");
					throw new ExecutionException(response.build());
				}
				// ADD
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					
					if(item.getIpwonType().equals("0")){
						List<ComboListItemInfo> list = inp1001Repository.getPkinp1001JaewonFlag(hospCode, bunho, ipwonDate);
						if (!CollectionUtils.isEmpty(list) && list.size() > 0){
							if(list.get(0).getCodeName().equals("Y")){
								LOGGER.info(String.format("Error message = 293, hosp_code = %s", hospCode));
								response.setResult(false);
								response.setMsg("293");
								throw new ExecutionException(response.build());
							}
						}
					}
					
					if(item.getChojae().equals("")){
						LOGGER.info(String.format("Error message = 3278, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("3278");
						throw new ExecutionException(response.build());
					}
					
					retval = bas0260Repository.getExsitReserDateINP1003U01SaveLayout(hospCode, item.getGwa(), DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD));
					if((retval == null) || (retval != null & !retval.equals("Y"))){
						LOGGER.info(String.format("Error message = 297, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("297");
						throw new ExecutionException(response.build());
					}
					
					retval = bas0270Repository.getExsitReserDateINP1003U01SaveLayout(hospCode, item.getGwa()
							, DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD), item.getDoctor());
					
					if((retval == null) || (retval != null & !retval.equals("Y"))){
						LOGGER.info(String.format("Error message = 298, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("298");
						throw new ExecutionException(response.build());
					}
					
					if(item.getIpwonDate() == ""){
						LOGGER.info(String.format("Error message = 327, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("327");
						throw new ExecutionException(response.build());
					}
					
					if(item.getIpwonTime() == ""){
						LOGGER.info(String.format("Error message = 328, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("328");
						throw new ExecutionException(response.build());
					}
					
					if(item.getIpwonType() == ""){						
						LOGGER.info(String.format("Error message = 330, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("330");
						throw new ExecutionException(response.build());
					}
					
					if(!item.getIpwonType().equals("2") && !item.getIpwonType().equals("3")){
						retval = bas0260Repository.inp1001U01checkExist(hospCode, item.getHoDong1(), DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD));
						if((retval == null) || (retval != null & !retval.equals("Y"))){
							LOGGER.info(String.format("Error message = 3317, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("3317");
							throw new ExecutionException(response.build());
						}
						
						retval = bas0250Repository.inp1001U00CheckExist(hospCode, item.getHoDong1(), item.getHoCode1(), DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD));
						if((retval == null) || (retval != null & !retval.equals("Y"))){
							LOGGER.info(String.format("Error message = 3318, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("3318");
							throw new ExecutionException(response.build());
						}
						
						retval = bas0253Repository.inp1001U01CheckIsExist(hospCode, item.getHoDong1(), item.getHoCode1()
								, item.getBedNo(), DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD));
						if((retval == null) || (retval != null & !retval.equals("Y"))){
							LOGGER.info(String.format("Error message = 3319, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("3319");
							throw new ExecutionException(response.build());
						}
						
						if(item.getHoDong1() == "" || item.getHoCode1() == "" || item.getBedNo() == ""){
							LOGGER.info(String.format("Error message = 331, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("331");
							throw new ExecutionException(response.build());
						}
						
						retval = inp1001Repository.inp1001U01checkIsExist(hospCode, item.getHoDong1(), item.getHoCode1(), item.getBedNo());
						if(retval != null & retval.equals("Y")){
							LOGGER.info(String.format("Error message = 295, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("295");
							throw new ExecutionException(response.build());
						}
						
						retval = bas0250Repository.inp1001U01CheckBedIsPossible(hospCode, item.getHoCode1(), item.getBedNo()
								, item.getHoDong1(), DateUtil.toDate(item.getSilIpwonDate(), DateUtil.PATTERN_YYMMDD));
						if(retval != null & retval.equals("Y")){
							LOGGER.info(String.format("Error message = 296, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("296");
							throw new ExecutionException(response.build());
						}
					}// end if check ipwon_type
					
					if((item.getFkinp1003() == "")||(item.getFkinp1003() != "" && item.getPkinp1001() == "")){
						retval = inp1003Repository.inp1001U01CheckIsExist(hospCode, bunho);
						if(retval != null & retval.equals("Y")){
							LOGGER.info(String.format("Error message = 3443, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("3443");
							throw new ExecutionException(response.build());
						}
					}
					
					Double pkinp1001;
					Double fkInpKey;
					if(item.getPkinp1001() == ""){
						pkinp1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1001_SEQ"));
						if(pkinp1001 == null){
							LOGGER.info(String.format("Error message = INP1001_SEQ, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("INP1001_SEQ");
							throw new ExecutionException(response.build());
						}
					}else
						pkinp1001 = CommonUtils.parseDouble(item.getPkinp1001());
					
					if(!item.getIpwonType().equals("2")){
						fkInpKey = pkinp1001;
					}else{
						fkInpKey = inp1001Repository.getListPkinp1001(hospCode, bunho);
					}
					
					if(!insertInp1001(item, fkInpKey, pkinp1001, request.getUserId(), hospCode)){
						LOGGER.info(String.format("Error message = INP1001 Insert Error, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("INP1001 Insert Error");
						throw new ExecutionException(response.build());
					}
					sPkinp1001 = pkinp1001.toString();
					Integer cnt = inp1001Repository.checkJubsuCnt(hospCode, bunho, ipwonDate);
					if(cnt == null){
						LOGGER.info(String.format("Error message = FN_OUT_CHECK_JUBSU_CNT error, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("FN_OUT_CHECK_JUBSU_CNT Error");
						throw new ExecutionException(response.build());
					}
					
				}
				//MODIFIED
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					if(item.getPkinp1001() == ""){
						LOGGER.info(String.format("Error message = 321, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("321");
						throw new ExecutionException(response.build());
					}
					
					bunho = item.getBunho();
					if(bunho == ""){
						LOGGER.info(String.format("Error message = 283, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("283");
						throw new ExecutionException(response.build());
					}
					
					if(inp1001Repository.updateInp1001U01DoubleSaveLayout(hospCode, request.getUserId(), item.getIpwonTime(), item.getIpwonGwa(), item.getGwa(),
							item.getDoctor(), item.getResident(), item.getHoCode1(), item.getHoDong1(), item.getHoGrade1(), item.getHoCode2(), item.getHoDong2(),
							item.getIpwonRtn2(), item.getChojae(), item.getBabyStatus(), item.getInpTransYn(), CommonUtils.parseDouble(item.getFkout1001()),
							item.getJaewonFlag(), item.getToiwonGojiYn(), item.getToiwonResDate(), item.getGaToiwonDate(), item.getToiwonDate(), item.getToiwonTime(),
							item.getResult(), item.getSigiMagamYn(), item.getCancelDate(), item.getCancelUser(), item.getCancelYn(), CommonUtils.parseDouble(item.getFkinp1003()),
							item.getTeam(), item.getIpwonDate(), item.getBedNo(), item.getGisanIpwonDate(), item.getJisiDoctor(), CommonUtils.parseDouble(item.getPkinp1001())) < 0){
						LOGGER.info(String.format("Error message = UPDATE INP1001 FALSE, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("UPDATE INP1001 FALSE");
						throw new ExecutionException(response.build());
					}						
				}
			}
		} // END list INP1001
		
		// list INP1002
		if(!CollectionUtils.isEmpty(request.getLayInp1002List())){
			for(INP1001U01DoubleLayINP1002Info item : request.getLayInp1002List()){
				
				String pkinp1001;
				String fkinp1001;
				Double pkinp1002;
				Double seq;
				if(sPkinp1001 == "")
					sPkinp1001 = request.getPkinp1001ForC2();
				pkinp1001 = sPkinp1001;
				if(item.getFkinp1001() == ""){
					fkinp1001 = pkinp1001;
				}else{
					fkinp1001 = item.getFkinp1001();
				}
				
				switch(item.getIudGubun()){
				case "I":
					if(pkinp1001 == ""){
						LOGGER.info(String.format("Error message = INP1001 PK is NULL, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("INP1001 PK is NULL");
						throw new ExecutionException(response.build());
					}
					if(fkinp1001 == ""){
						LOGGER.info(String.format("Error message = 340, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("340");
						throw new ExecutionException(response.build());
					}
					retval = bas0210Repository.getBAS0210U00DupCheckext(language, item.getGubun(), DateUtil.toDate(item.getGubunIpwonDate(), DateUtil.PATTERN_YYMMDD));
					if((retval == null)||(retval != null && !retval.equals("Y"))){
						LOGGER.info(String.format("Error message = 338, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("338");
						throw new ExecutionException(response.build());
					}
					
					retval = bas0210Repository.getNuroChkGetGongbiYN(item.getGubun(), item.getGubunIpwonDate(), language);
					if(retval == null){
						LOGGER.info(String.format("Error message = 361, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("361");
						throw new ExecutionException(response.build());
					}
					
					if(retval.equals("Y") && item.getFromJyDate() == ""){
						LOGGER.info(String.format("Error message = 358, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("358");
						throw new ExecutionException(response.build());
					}
					
					CommonProcResultInfo result = inp1002Repository.callPrInpMakePkinp1002(CommonUtils.parseDouble(fkinp1001), item.getGubun(), hospCode);
					if(result.getStrResult1() == "" || result.getStrResult2() == ""){
						LOGGER.info(String.format("Error message = 358, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("358");
						throw new ExecutionException(response.build());
					}else{
						pkinp1002 = CommonUtils.parseDouble(result.getStrResult1());
						seq = CommonUtils.parseDouble(result.getStrResult2());
					}
					
					if(pkinp1002 == null){
						LOGGER.info(String.format("Error message = 189, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("189");
						throw new ExecutionException(response.build());
					}
					mPKINP1002 = pkinp1002.toString();
					
					if(!insertInp1002(item, hospCode, request.getUserId(), CommonUtils.parseDouble(fkinp1001), pkinp1002, seq)){
						LOGGER.info(String.format("Error message = INP1002 Insert Error, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("INP1002 Insert Error");
						throw new ExecutionException(response.build());
					}
					// TO DO : check mIpwonsi_Order for calling  PR_OCS_UPDATE_INP_ORDER_RES or not
					break;
					
					default:
						break;
				}
			
			}
		} // End list INP1002
		
		// list INP1003
		if(!CollectionUtils.isEmpty(request.getLayInp1002List())){
			for(INP1001U01DoubleGrdINP1008Info item : request.getGrdInp1008List()){
				String pkinp1002 = "";
				String fkinp1002 = "";
				if(mPKINP1002 == ""){
					pkinp1002 = request.getPkinp1002ForC3();
				}else{
					pkinp1002 = mPKINP1002;
				}
				
				switch(item.getNValue()){
				case "Y":
					if(item.getFkinp1002() == ""){
						if(pkinp1002 == ""){
							LOGGER.info(String.format("Error message = INP1002 PK is null, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("INP1002 PK is null");
							throw new ExecutionException(response.build());
						}
						fkinp1002 = pkinp1002;
					}
					if(fkinp1002 == ""){
						LOGGER.info(String.format("Error message = 190, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("190");
						throw new ExecutionException(response.build());
					}
					retval = out0105Repository.inp1001U01CheckIsExistCode(hospCode, item.getBunho(), item.getGongbiCode());
					if((retval == null)||(retval != null && !retval.equals("Y"))){
						LOGGER.info(String.format("Error message = 359, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("359");
						throw new ExecutionException(response.build());
					}
					if(inp1008Repository.recordCount(hospCode, CommonUtils.parseDouble(fkinp1002), item.getGongbiCode()) > 0){
						if(inp1008Repository.updateInInp1001U01(hospCode, CommonUtils.parseDouble(fkinp1002), item.getGongbiCode()) < 0){
							throw new ExecutionException(response.build());
						}
					}else
						if(!insertInp1008(item, hospCode, request.getUserId(), pkinp1002)){
							throw new ExecutionException(response.build());
						}
					break;
					
				case "N":
					if(item.getFkinp1002() == ""){
						if(pkinp1002 == ""){
							LOGGER.info(String.format("Error message = INP1002 PK is null, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("INP1002 PK is null");
							throw new ExecutionException(response.build());
						}
						fkinp1002 = pkinp1002;
					}
					if(inp1008Repository.deleteInInp1001U01(hospCode, CommonUtils.parseDouble(fkinp1002), item.getGongbiCode()) < 0){

						throw new ExecutionException(response.build());
					}
					break;
					
					default:
						break;
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private boolean insertInp1001(INP1001U01DoubleLayINP1001Info item, Double fkInpKey, Double pkinp1001, String sysId, String hospCode){
		Inp1001 inp1001 = new Inp1001();
		
		inp1001.setSysDate(new Date());
		inp1001.setSysId(sysId);
		inp1001.setUpdDate(new Date());
		inp1001.setUpdId(sysId);
		inp1001.setHospCode(hospCode);
		inp1001.setPkinp1001(pkinp1001);
		inp1001.setBunho(item.getBunho());

		if(!item.getIpwonDate().isEmpty() && DateUtil.toDate(item.getChtIpwonDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setIpwonDate(DateUtil.toDate(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		}
		if(item.getIpwonTime() != "" && item.getToiwonTime().indexOf(':') > -1 ){
			inp1001.setIpwonType(item.getIpwonType().substring(0, 2) + item.getIpwonTime().substring(3, 5));		
		}else
			inp1001.setIpwonType(item.getIpwonType());
		inp1001.setIpwonGwa(item.getIpwonGwa());
		inp1001.setGwa(item.getGwa());
		inp1001.setDoctor(item.getDoctor());
		inp1001.setResident(item.getResident());
		inp1001.setHoCode1(item.getHoCode1());
		inp1001.setHoDong1(item.getHoDong1());
		inp1001.setHoGrade1(item.getHoGrade1());
		inp1001.setHoCode2(item.getHoCode2());
		inp1001.setHoDong2(item.getHoDong2());
		inp1001.setIpwonRtn2(item.getIpwonRtn2());
		inp1001.setChojae(item.getChojae());
		inp1001.setBabyStatus(item.getBabyStatus());
		inp1001.setInpTransYn(item.getInpTransYn());
		inp1001.setFkout1001((item.getFkout1001()));
		inp1001.setJaewonFlag(item.getJaewonFlag());
		inp1001.setToiwonGojiYn(item.getToiwonGojiYn());
		
		if(!item.getToiwonResDate().isEmpty() && DateUtil.toDate(item.getToiwonResDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setToiwonResDate(DateUtil.toDate(item.getToiwonResDate(), DateUtil.PATTERN_YYMMDD));
		}
		inp1001.setToiwonResTime(null);
		
		if(!item.getGaToiwonDate().isEmpty() && DateUtil.toDate(item.getGaToiwonDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setGaToiwonDate(DateUtil.toDate(item.getGaToiwonDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		if(!item.getToiwonDate().isEmpty() && DateUtil.toDate(item.getToiwonDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setToiwonDate(DateUtil.toDate(item.getToiwonDate(), DateUtil.PATTERN_YYMMDD));
		}
		inp1001.setToiwonTime(item.getToiwonTime());
		inp1001.setResult(item.getResult());
		inp1001.setSigiMagamYn(item.getSigiMagamYn());
		inp1001.setSimsaMagamGubun(item.getSimsaMagamGubun());
		
		if(!item.getCancelDate().isEmpty() && DateUtil.toDate(item.getCancelDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setCancelDate(DateUtil.toDate(item.getCancelDate(), DateUtil.PATTERN_YYMMDD));
		}
		inp1001.setCancelUser(item.getCancelUser());
		inp1001.setCancelYn(item.getCancelYn());
		inp1001.setFkinp1003(CommonUtils.parseDouble(item.getFkinp1003()));
		inp1001.setTeam(item.getTeam());
		inp1001.setSimsaMagamDate(null);
		inp1001.setSimsaMagamTime(null);
		
		if(!item.getIpwonDate().isEmpty() && DateUtil.toDate(item.getIpwonDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1001.setGisanIpwonDate(DateUtil.toDate(item.getIpwonDate(), DateUtil.PATTERN_YYMMDD));
		}
		inp1001.setBedNo(item.getBedNo());
		inp1001.setGisanJaewonIlsu(CommonUtils.parseDouble(item.getGisanJaewonIlsu()));
		inp1001.setJisiDoctor(item.getJisiDoctor());
		inp1001.setFkInpKey(fkInpKey);
		
		inp1001Repository.save(inp1001);
		return true;
	}
	
	private boolean insertInp1002(INP1001U01DoubleLayINP1002Info item, String hospCode, String userId, Double fkinp1001, Double pkinp1002, Double seq){
		Inp1002 inp1002 = new Inp1002();
		inp1002.setSysDate(new Date());
		inp1002.setSysId(userId);
		inp1002.setUpdDate(new Date());
		inp1002.setUpdId(userId);
		inp1002.setPkinp1002(pkinp1002.toString());
		inp1002.setFkinp1001(fkinp1001);
		inp1002.setBunho(item.getBunho());
		inp1002.setGubun(item.getGubun());
		inp1002.setSeq(seq);
		inp1002.setGubunTransDate(null);
		
		if(!item.getGubunIpwonDate().isEmpty() && DateUtil.toDate(item.getGubunIpwonDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1002.setGubunIpwonDate(DateUtil.toDate(item.getGubunIpwonDate(), DateUtil.PATTERN_YYMMDD));
		}
		inp1002.setGubunToiwonDate(null);
		inp1002.setGubunTransCnt(CommonUtils.parseDouble(item.getGubunTransCnt()));
		inp1002.setGubunTransYn(item.getGubunTransYn());
		inp1002.setSimsaja(null);
		inp1002.setSimsaMagamYn(item.getSimsaMagamYn());
		
		inp1002Repository.save(inp1002);
		return true;
	}

	private boolean insertInp1008(INP1001U01DoubleGrdINP1008Info item, String hospCode, String userId, String pkinp1002){
		Inp1008 inp1008 = new Inp1008();
		inp1008.setSysDate(new Date());
		inp1008.setSysId(userId);
		inp1008.setUpdDate(new Date());
		inp1008.setUpdId(userId);
		inp1008.setHospCode(hospCode);
		inp1008.setFkinp1002(pkinp1002);
		inp1008.setGongbiCode(item.getGongbiCode());
		inp1008.setBunho(item.getBunho());
		inp1008Repository.save(inp1008);
		
		return true;
		
	}
}
