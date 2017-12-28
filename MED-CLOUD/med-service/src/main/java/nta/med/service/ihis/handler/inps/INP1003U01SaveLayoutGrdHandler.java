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
import nta.med.core.domain.inp.Inp1003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.bass.INP1003ChkBunhoListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.inps.INP1003U01layDeleteInfo;
import nta.med.service.ihis.proto.InpsModelProto.INP1003U01grdINP1003Info;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                        
@Scope("prototype")
public class INP1003U01SaveLayoutGrdHandler extends ScreenHandler<InpsServiceProto.INP1003U01SaveLayoutGrdRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(INP1003U01SaveLayoutGrdHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Transactional
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, InpsServiceProto.INP1003U01SaveLayoutGrdRequest request) throws Exception{
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(CollectionUtils.isEmpty(request.getGrdSaveList())){
			response.setResult(false);
		} else {
			for(INP1003U01grdINP1003Info item : request.getGrdSaveList()){
				Date reserDate = DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD);
				Date currentDate = DateUtil.toDate(DateUtil.getCurrentDateTime(DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD);
				String bunho = "";
				String gwa = "";
				String doctor = "";
				Double pkinp1003;
				Double pkinp1001;
				
				if(reserDate.compareTo(currentDate) < 0){
					LOGGER.info(String.format("Error message = 3739, hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg("3739");
					throw new ExecutionException(response.build());
				}
				String retval =  "";
				retval = bas0260Repository.getExsitReserDateINP1003U01SaveLayout(hospCode, item.getGwa(), reserDate);
				
				if((retval == null || retval.length() == 0) || (retval != null && retval.length() != 0 && !retval.equals("Y"))){
					LOGGER.info(String.format("Error message = 241, hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg("241");
					throw new ExecutionException(response.build());
					//return response.build();
				}
				
				retval = bas0270Repository.getExsitReserDateINP1003U01SaveLayout(hospCode, item.getGwa(), reserDate, item.getDoctor());
				
				if((retval == null || retval.length() == 0) || (retval != null && retval.length() != 0 && !retval.equals("Y"))){					
					response.setResult(false);
					LOGGER.info(String.format("Error message = 2080, hosp_code = %s", hospCode));
					response.setMsg("2080");
					throw new ExecutionException(response.build());
					//return response.build();
				}
				
				bunho = item.getBunho();
				
				String tel = "";
				tel = out0101Repository.getTelINP1003U01SaveLayout(hospCode, bunho);
				if(tel == null || tel.length() == 0)
					tel = "";
				
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					bunho = item.getBunho();
					if(bunho == null || bunho.length() == 0){
						response.setResult(false);
						LOGGER.info(String.format("Error message = 290, hosp_code = %s", hospCode));
						response.setMsg("290");
						throw new ExecutionException(response.build());
						//return response.build();
					}
				
					String mess = methodCheckBunho(item.getBunho(), hospCode, language);
					if (!mess.equals("0")){
						LOGGER.info(String.format("Error message = %s, hosp_code = %s", mess, hospCode));
						response.setResult(false);
						response.setMsg(mess);
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					retval = inp1003Repository.getExsitINP1003U01SaveLayout(hospCode, bunho);
					if(retval != null && retval.length() != 0 && retval.equals("Y")){
						LOGGER.info(String.format("Error message = 3162, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("3162");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					if(methodIsJeawon(bunho, reserDate, hospCode) == "Y"){
						LOGGER.info(String.format("Error message = 293, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("293");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					gwa = item.getGwa();					
					if(gwa == null || gwa.length() == 0){
						LOGGER.info(String.format("Error message = 297, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("297");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					doctor = item.getDoctor();
					if(doctor == null || doctor.length() == 0){
						LOGGER.info(String.format("Error message = 298, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("298");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					pkinp1003 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1003_SEQ"));
					if(pkinp1003 == null){
						LOGGER.info(String.format("Error message = PKINP1003, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("PKINP1003");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					pkinp1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1001_SEQ"));
					if(pkinp1001 == null){
						LOGGER.info(String.format("Error message = PKINP1001, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("PKINP1001");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					response.setResult(insertInp1003(hospCode, request.getUserid(), item, CommonUtils.parseDouble(request.getFkout1001()), pkinp1003, tel, pkinp1001, "1"));
					
					inp1003Repository.prOcsInitCreateSiksa(hospCode, pkinp1001, bunho, item.getReserDate(), "I", language);
					
				}else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					pkinp1003 = CommonUtils.parseDouble(item.getPkinp1003());
					if(methodIsJeawon(bunho, reserDate, hospCode).equals("Y")){
						LOGGER.info(String.format("Error message = 293, hosp_code = %s", hospCode));
						response.setResult(false);
						response.setMsg("293");
						throw new ExecutionException(response.build());
						//return response.build();
					}
					
					String codeCheckExistReser = inp1003Repository.checkExistReser(hospCode, pkinp1003, reserDate);
					switch (codeCheckExistReser){
					case "1":
						pkinp1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1001_SEQ"));
						if(pkinp1001 == null){
							LOGGER.info(String.format("Error message = PKINP1001, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("PKINP1001");
							throw new ExecutionException(response.build());
							//return response.build();
						}
						if(inp1003Repository.Inp1003U01UpdateInp1003(request.getUserid(), CommonUtils.parseDouble(item.getReserFkinp1001()), item.getRemark()
								, item.getSangBigo(), item.getEmergencyGubun(), item.getEmergencyDetail(), hospCode, pkinp1003) > 0)
							response.setResult(true);
						else
							response.setResult(false);
						break;
						
					case "2":
						inp1003Repository.Inp1003U01UpdateReserEndDate(hospCode, pkinp1003);
						pkinp1003 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1003_SEQ"));
						if(pkinp1003 == null){
							LOGGER.info(String.format("Error message = PKINP1003, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("PKINP1003");
							throw new ExecutionException(response.build());
							//return response.build();
						}
						pkinp1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INP1001_SEQ"));
						if(pkinp1001 == null){
							LOGGER.info(String.format("Error message = PKINP1001, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("PKINP1001");
							throw new ExecutionException(response.build());
							//return response.build();
						}
						response.setResult(insertInp1003(hospCode, request.getUserid(), item, CommonUtils.parseDouble(request.getFkout1001()), pkinp1003, tel, pkinp1001, "2"));
						break;
					case "3":
						if(inp1003Repository.Inp1003UpdateInp1003(request.getUserid(), item.getDoctor(), item.getRemark(), item.getJisiDoctor(), item.getSangBigo(), item.getHoDong(),
								item.getHoCode(), item.getBedNo(), item.getEmergencyGubun(), item.getEmergencyDetail(), hospCode, pkinp1003) > 0)
							response.setResult(true);
						else
							response.setResult(false);
						break;
					case "4":
						List<INP1003U01layDeleteInfo> list = inp1003Repository.getINP1003U01layDeleteInfo(hospCode, pkinp1003);
						if(CollectionUtils.isEmpty(list)||list.size()==0){
							LOGGER.info(String.format("Error message = 2109, hosp_code = %s", hospCode));
							response.setResult(false);
							response.setMsg("2109");
							throw new ExecutionException(response.build());
							//return response.build();
						}else{
							String tBunho = list.get(0).getBunho();
							Double tFkinp1001 = list.get(0).getReserFkinp1001();
							Date reserDateOld = DateUtil.toDate(list.get(0).getReserDate(), DateUtil.PATTERN_YYMMDD);
							
							ComboListItemInfo combo = inp1003Repository.prcOcsAlterReserInpwonDate(hospCode, tBunho, tFkinp1001, reserDateOld, reserDate, request.getUserid());
							if(combo.getCodeName().equals("0") || combo.getCodeName().equals("1")){
								if(inp1003Repository.Inp1003UpdateInp1003(request.getUserid(), item.getDoctor(), item.getGwa(), DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD),
										item.getRemark(), item.getJisiDoctor(), item.getSangBigo(), item.getHoDong(),
										item.getHoCode(), item.getBedNo(), item.getEmergencyGubun(), item.getEmergencyDetail(), hospCode, pkinp1003) > 0)
									response.setResult(true);
								else
									response.setResult(false);
							}
						}
						break;
					default:
							response.setResult(false);
							break;
					}
					inp1003Repository.prOcsInitCreateSiksa(hospCode, CommonUtils.parseDouble(item.getReserFkinp1001()), bunho, item.getReserDate(), "I", language);
						
				}else{
					
				}
			} //end for
		}
		return response.build();
	}
	
	private String methodCheckBunho(String bunho, String hospCode, String language){
		List<INP1003ChkBunhoListItemInfo> list  =  out0101Repository.getINP1003ChkBunhoListItemInfo(hospCode, language, bunho);
		if(CollectionUtils.isEmpty(list)){
			return "290";
		}
		if(!list.get(0).getDeleteYn().equals("N")){
			return "291";
		}
		if(!list.get(0).getJubsuBreak().equals("N")){
			return "292";
		}
		return "0";
	}
	
	private String methodIsJeawon(String bunho, Date reserDate, String hospCode){
		List<ComboListItemInfo> list = inp1001Repository.getPkinp1001JaewonFlag(hospCode, bunho, reserDate);
		if(CollectionUtils.isEmpty(list)){
			return "Error";
		}	
		return list.get(0).getCodeName();
	}
	
	private boolean insertInp1003(String hospCode, String userId, INP1003U01grdINP1003Info item, Double fkout1001, Double pkinp1003, String tel, Double reserFkinp1001, String mode){
		Inp1003 inp1003 = new Inp1003();
		
		inp1003.setSysId(userId);
		inp1003.setSysDate(new Date());
		inp1003.setUpdId(userId);
		inp1003.setUpdDate(new Date());
		inp1003.setHospCode(hospCode);

		inp1003.setPkinp1003(pkinp1003);
		inp1003.setJunpyoDate(new Date());
		inp1003.setBunho(item.getBunho());
		inp1003.setTel1(tel);
		inp1003.setTel2(tel);
		
		if(!item.getReserDate().isEmpty() && DateUtil.toDate(item.getReserDate(),DateUtil.PATTERN_YYMMDD) != null){
			inp1003.setReserDate(DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		inp1003.setGwa(item.getGwa());
		inp1003.setDoctor(item.getDoctor());
		inp1003.setHoCode(item.getHoCode());
		inp1003.setReserEndType("0");
		inp1003.setSusulReserYn("N");
		inp1003.setIpwonRtn2("1");//外来
		inp1003.setHoDong(item.getHoDong());
		inp1003.setBedNo(item.getBedNo());
		if(mode.equals("2"))
			inp1003.setIpwonMokjuk("17");
		inp1003.setReserFkinp1001(reserFkinp1001);
		inp1003.setIpwonsiOrderYn("Y");//入院時可否
		inp1003.setRemark(item.getRemark());
		inp1003.setJisiDoctor(item.getJisiDoctor());
		inp1003.setSangBigo(item.getSangBigo());
		inp1003.setEmergencyGubun(item.getEmergencyGubun());
		inp1003.setEmergencyDetail(item.getEmergencyDetail());
		inp1003.setFkout1001(fkout1001);
		
		inp1003Repository.save(inp1003);
		return true;
		
	}
	
}
