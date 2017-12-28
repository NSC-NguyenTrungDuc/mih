package nta.med.service.ihis.handler.bass;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0310;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0310U00GrdListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")      
@Transactional
public class BAS0310U00TransactionalHandler extends ScreenHandler<BassServiceProto.BAS0310U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0310U00TransactionalHandler.class);                                    
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;       
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0310U00TransactionalRequest request) throws Exception {                                                             
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
  	   	String hospitalCode = getHospitalCode(vertx, sessionId);
		response = executeTransaction(hospitalCode, request);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	private SystemServiceProto.UpdateResponse.Builder executeTransaction(String hospitalCode, BassServiceProto.BAS0310U00TransactionalRequest request){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<BAS0310U00GrdListItemInfo> listItem = request.getListInputInfoList();
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0310U00GrdListItemInfo item : listItem){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())) {
					if("".equalsIgnoreCase(item.getSgCode())){
						response.setMsg("Resource.TEXT44, Resource.TEXT48, MessageBoxIcon.Error");
						response.setResult(false);
						return response;
					} else if("".equalsIgnoreCase(item.getSgYmd())){
						response.setMsg("Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error");
						response.setResult(false);
						return response;
					}
					Date sgYmd = DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD);
					//
					String tChk = bas0310Repository.getYFromBAS0310ItemInfo(hospitalCode, item.getSgCode(), sgYmd);
					if("Y".equalsIgnoreCase(tChk)){
						response.setMsg("Resource.TEXT50, Resource.TEXT51, Resource.TEXT48, MessageBoxIcon.Error");
						response.setResult(false);
						return response;
					}
					//
					Calendar cal = Calendar.getInstance();
					cal.setTime(DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD));
					cal.add(Calendar.DATE, -1);
					Date bulyongYmd = cal.getTime();
					
					bas0310Repository.updateBAS0310WhereHospSgCodeYmd2(new Date(), request.getUserId(), bulyongYmd, ModifyFlg.UPDATE.getValue(), hospitalCode, item.getSgCode(), sgYmd, item.getPrivateFeeYn());
					//
					
					Bas0310 bas0310 = new Bas0310();
					bas0310.setSysDate(new Date());
					bas0310.setSysId(request.getUserId());
					bas0310.setUpdDate(new Date());
					bas0310.setUpdId(request.getUserId());
					bas0310.setHospCode(hospitalCode);
					bas0310.setSgCode(item.getSgCode());
					if(!StringUtils.isEmpty(item.getSgName())){
						bas0310.setSgName(item.getSgName());
					} else {
						bas0310.setSgName("");
					}
					if(!StringUtils.isEmpty(item.getSgNameKana())){
						bas0310.setSgNameKana(item.getSgNameKana());
					} else {
						bas0310.setSgNameKana("");
					}
					bas0310.setSgYmd(sgYmd);
					if(StringUtils.isEmpty(item.getBulyongYmd())){
						bas0310.setBulyongYmd((DateUtil.toDate(item.getBulyongYmd(), DateUtil.PATTERN_YYMMDD)));
					} else {
						bas0310.setBulyongYmd((DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD)));
					}
					bas0310.setSgUnion(item.getSgUnion());
					bas0310.setGroupGubun(item.getGroupGubun());
					if(!StringUtils.isEmpty(item.getBunCode())){
						bas0310.setBunCode(item.getBunCode());
					} else {
						bas0310.setBunCode("");
					}
					bas0310.setMarumeGubun(item.getMarumeGubun());
					bas0310.setHubalDrgYn(item.getHubalDrgYn());
					bas0310.setDanui(item.getDanui());
					bas0310.setSunabQcodeOut(item.getSunabQcodeOut());
					bas0310.setSunabQcodeInp(item.getSunabQcodeInp());
					bas0310.setSugaChange(item.getSugaChange());
					bas0310.setBulyongSayu(item.getBulyongSayu());
					bas0310.setRemark(item.getRemark());
					bas0310.setTaxYn(item.getTaxYn());
					bas0310.setModifyFlg(ModifyFlg.INSERT.getValue());
					bas0310.setPrivateFeeYn(item.getPrivateFeeYn());
					bas0310Repository.save(bas0310);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
					if("".equalsIgnoreCase(item.getSgYmd())){
						response.setMsg("Resource.TEXT49, Resource.TEXT48, MessageBoxIcon.Error");
						response.setResult(false);
						return response;
					}
					
					boolean updateResult = false;
					if(!ModifyFlg.READ.getValue().equals(item.getModifyFlg())){
						updateResult = bas0310Repository.updateBAS0310WhereHospSgCodeYmd(request.getUserId(), new Date(), item.getSgName(), item.getSgNameKana(), 
								DateUtil.toDate(item.getBulyongYmd(), DateUtil.PATTERN_YYMMDD),  item.getSgUnion(),  item.getGroupGubun(),  item.getBunCode(),
								 item.getMarumeGubun(),  item.getHubalDrgYn(),  item.getDanui(),  item.getSunabQcodeOut(),  item.getSunabQcodeInp(),
								 item.getSugaChange(),  item.getBulyongSayu(),  item.getRemark(),  item.getTaxYn(), ModifyFlg.UPDATE.getValue(), hospitalCode,  item.getSgCode(), 
								 DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD), item.getPrivateFeeYn()) > 0;
					} else {
						updateResult = bas0310Repository.updateBAS0310WhereHospSgCodeYmdIgnoreModifyFlg(request.getUserId(), new Date(), item.getSgName(), item.getSgNameKana(), 
								DateUtil.toDate(item.getBulyongYmd(), DateUtil.PATTERN_YYMMDD),  item.getSgUnion(),  item.getGroupGubun(),  item.getBunCode(),
								 item.getMarumeGubun(),  item.getHubalDrgYn(),  item.getDanui(),  item.getSunabQcodeOut(),  item.getSunabQcodeInp(),
								 item.getSugaChange(),  item.getBulyongSayu(),  item.getRemark(),  item.getTaxYn(), hospitalCode,  item.getSgCode(), 
								 DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD), item.getPrivateFeeYn()) > 0;
					}
					
//					if(bas0310Repository.updateBAS0310WhereHospSgCodeYmd(request.getUserId(), new Date(), item.getSgName(), item.getSgNameKana(), 
//							DateUtil.toDate(item.getBulyongYmd(), DateUtil.PATTERN_YYMMDD),  item.getSgUnion(),  item.getGroupGubun(),  item.getBunCode(),
//							 item.getMarumeGubun(),  item.getHubalDrgYn(),  item.getDanui(),  item.getSunabQcodeOut(),  item.getSunabQcodeInp(),
//							 item.getSugaChange(),  item.getBulyongSayu(),  item.getRemark(),  item.getTaxYn(), ModifyFlg.UPDATE.getValue(), hospitalCode,  item.getSgCode(), 
//							 DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD), item.getPrivateFeeYn()) <= 0){
//						response.setResult(false);
//						return response;
//					}
					
					if(!updateResult){
						response.setResult(false);
						return response;
					}
				} else if(DataRowState.DELETED.getValue().equals(item.getRowState())) {
					String tChk = ocs0103Repository.getYFromOCS0103ItemInfo(hospitalCode, item.getSgCode());
					if("Y".equalsIgnoreCase(tChk)){
						response.setMsg("Resource.TEXT50, Resource.TEXT52, Resource.TEXT53, Resource.TEXT48, MessageBoxIcon.Error");
						response.setResult(false);
						return response;
					}
					Date sgYmd = DateUtil.toDate(item.getSgYmd(), DateUtil.PATTERN_YYMMDD);
					if(bas0310Repository.deleteBAS0310WhereHospSgCodeYmd(hospitalCode, item.getSgCode(), sgYmd) <= 0){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		response.setResult(true);
		return response;
	}
}