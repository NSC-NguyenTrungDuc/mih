package nta.med.service.ihis.handler.ocsa;

import java.text.ParseException;
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEGrdOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCSAPPROVEGrdOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSAPPROVEGrdOrderHandler
	extends ScreenHandler<OcsaServiceProto.OCSAPPROVEGrdOrderRequest, OcsaServiceProto.OCSAPPROVEGrdOrderResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCSAPPROVEGrdOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCSAPPROVEGrdOrderRequest request)
			throws Exception {                                                                
      	   	OcsaServiceProto.OCSAPPROVEGrdOrderResponse.Builder response = OcsaServiceProto.OCSAPPROVEGrdOrderResponse.newBuilder();
      	   	String hospCode = getHospitalCode(vertx, sessionId);
      	   	String language = getLanguage(vertx, sessionId);
			List<OCSAPPROVEGrdOrderInfo> list = ocs1003Repository.getOCSAPPROVEGrdOrderListItem(hospCode, language, CommonUtils.parseDouble(request.getPkOrder()),
					request.getInputTab(), request.getInsteadYn(), request.getApproveYn(), request.getPrepostGubun(), request.getBunho(), request.getJubsuNo(), request.getDoctor(),
					DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD),false,"","","");
			if(!CollectionUtils.isEmpty(list)){
				for(OCSAPPROVEGrdOrderInfo item : list){
					OcsaModelProto.OCSAPPROVEGrdOrderInfo.Builder info = OcsaModelProto.OCSAPPROVEGrdOrderInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					String buyoCheck = "N";
					buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
					if(!buyoCheck.equalsIgnoreCase("Y")){
						buyoCheck = "N";
					}else if(buyoCheck.equalsIgnoreCase("Y") && item.getBulyongCheck().equalsIgnoreCase(item.getHangmogCode())){
						buyoCheck = "Z";
					}else{
						buyoCheck = "Y";
					}
					info.setBulyongCheck(buyoCheck);
				}
			}
				
			List<OCSAPPROVEGrdOrderInfo> listUnion = ocs1003Repository.getOCSAPPROVEGrdOrderListItemUnion(hospCode, language, CommonUtils.parseDouble(request.getPkOrder()),
					request.getInputTab(), request.getInsteadYn(), request.getApproveYn(), request.getPrepostGubun(), request.getBunho(), request.getJubsuNo(), request.getDoctor(),
					DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD),false,"","","","");
			if(!CollectionUtils.isEmpty(listUnion)){
				for(OCSAPPROVEGrdOrderInfo item : listUnion){
					OcsaModelProto.OCSAPPROVEGrdOrderInfo.Builder info = OcsaModelProto.OCSAPPROVEGrdOrderInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					String buyoCheck = "N";
					buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
					info.setBulyongCheck(buyoCheck);
				}
			}
			// UNION ALL
			list.addAll(listUnion);
		    
		    // sort by CONT_KEY
		    Collections.sort( list, new Comparator<OCSAPPROVEGrdOrderInfo>()
		    {
				@Override
				public int compare(OCSAPPROVEGrdOrderInfo o1,
						OCSAPPROVEGrdOrderInfo o2) {
					if  (o1.getContKey() == null) return 1;
		        	if  (o2.getContKey() == null) return -1;
		            return (o2.getContKey()).compareTo( o1.getContKey() );
				}
		    } );
		    for(OCSAPPROVEGrdOrderInfo entry : list){
	            OcsaModelProto.OCSAPPROVEGrdOrderInfo.Builder info = OcsaModelProto.OCSAPPROVEGrdOrderInfo.newBuilder();
	            BeanUtils.copyProperties(entry, info, getLanguage(vertx, sessionId));
	            if (entry.getGroupSer() != null) {
	            	info.setGroupSer(String.format("%.0f",entry.getGroupSer()));
	            }
	            if (entry.getSuryang() != null) {
	            	info.setSuryang(String.format("%.0f",entry.getSuryang()));
	            }
	            if (entry.getDv() != null) {
	            	info.setDv(String.format("%.0f",entry.getDv()));
	            }
	            if (entry.getNalsu() != null) {
	            	info.setNalsu(String.format("%.0f",entry.getNalsu()));
	            }
	            if (entry.getPkOrder() != null) {
	            	info.setPkOrder(String.format("%.0f",entry.getPkOrder()));
	            }
	            if (entry.getSeq() != null) {
	            	info.setSeq(String.format("%.0f",entry.getSeq()));
	            }
	            if (entry.getPkocs1003() != null) {
	            	info.setPkocs1003(String.format("%.0f",entry.getPkocs1003()));
	            }
	            if (entry.getAmt() != null) {
	            	info.setAmt(String.format("%.0f",entry.getAmt()));
	            }
	            if (entry.getDv1() != null) {
	            	info.setDv1(String.format("%.0f",entry.getDv1()));
	            }
	            if (entry.getDv2() != null) {
	            	info.setDv2(String.format("%.0f",entry.getDv2()));
	            }
	            if (entry.getDv3() != null) {
	            	info.setDv3(String.format("%.0f",entry.getDv3()));
	            }
	            if (entry.getDv4() != null) {
	            	info.setDv4(String.format("%.0f",entry.getDv4()));
	            }
	            if (entry.getLimitSuryang() != null) {
	            	info.setLimitSuryang(String.format("%.0f",entry.getLimitSuryang()));
	            }
	            if (entry.getBomSourceKey() != null) {
	            	info.setBomSourceKey(String.format("%.0f",entry.getBomSourceKey()));
	            }
	            if (entry.getOrgKey() != null) {
	            	info.setOrgKey(String.format("%.0f",entry.getOrgKey()));
	            }
	            if (entry.getParentKey() != null) {
	            	info.setParentKey(String.format("%.0f",entry.getParentKey()));
	            }
	            if (entry.getFkout1001() != null) {
	            	info.setFkout1001(String.format("%.0f",entry.getFkout1001()));
	            }
	            if (entry.getDv5() != null) {
	            	info.setDv5(String.format("%.0f",entry.getDv5()));
	            }
	            if (entry.getDv6() != null) {
	            	info.setDv6(String.format("%.0f",entry.getDv6()));
	            }
	            if (entry.getDv7() != null) {
	            	info.setDv7(String.format("%.0f",entry.getDv7()));
	            }
	            if (entry.getDv8() != null) {
	            	info.setDv8(String.format("%.0f",entry.getDv8()));
	            }

	            response.addGrdOrderInfo(info);
	        }
		    return response.build();
	}
	private String fnOcsBulyongCheckOut(OCSAPPROVEGrdOrderInfo item,
			String buyoCheck) throws ParseException {
		Date date = DateUtil.toDate(item.getbBulyongYmd(), DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(item.getbBulyongYmd()) ||( date.equals(new Date()) || date.after(new Date()))){
			buyoCheck = "N";
		}else{
			buyoCheck = "Y";
		}
		return buyoCheck;
	}
}