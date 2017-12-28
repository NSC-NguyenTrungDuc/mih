package nta.med.service.ihis.handler.ocsa;

import java.text.ParseException;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0303Repository;
import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0303Info;
import nta.med.data.model.ihis.ocsa.OCS0307U00GrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09GrdOCS0303Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09GrdOCS0303Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09GrdOCS0303Handler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09GrdOCS0303Request, OcsaServiceProto.OCS0301Q09GrdOCS0303Response> {                     
	@Resource                                                                                                       
	private Ocs0303Repository ocs0303Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0301Q09GrdOCS0303Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0301Q09GrdOCS0303Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0301Q09GrdOCS0303Response.Builder response = OcsaServiceProto.OCS0301Q09GrdOCS0303Response.newBuilder();  
  	   	//repeated OCS0301Q09GrdOCS0303Info grd_ocs_0303_item = 1;
		List<OCS0301Q09GrdOCS0303Info> listGrd=ocs0303Repository.getOCS0301Q09GrdOCS0303(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getGenericYn(), request.getMemb(), CommonUtils.parseDouble(request.getFkocs0300Seq()), request.getYaksokCode(), request.getProtocolId());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0301Q09GrdOCS0303Info item : listGrd){
				OcsaModelProto.OCS0301Q09GrdOCS0303Info.Builder info =OcsaModelProto.OCS0301Q09GrdOCS0303Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkocs0303() !=null) {
					info.setPkocs0303(String.format("%.0f",item.getPkocs0303()));
				}
				if (item.getGroupSer() !=null) {
					info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				}
				if (item.getSeq() !=null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getSuryang() !=null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if (item.getDv() !=null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if (item.getDv1() !=null) {
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				if (item.getDv2() !=null) {
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				if (item.getDv3() !=null) {
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				if (item.getDv4() !=null) {
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				if (item.getDv5() !=null) {
					info.setDv5(String.format("%.0f",item.getDv5()));
				}
				if (item.getDv6() !=null) {
					info.setDv6(String.format("%.0f",item.getDv6()));
				}
				if (item.getDv7() !=null) {
					info.setDv7(String.format("%.0f",item.getDv7()));
				}
				if (item.getDv8() !=null) {
					info.setDv8(String.format("%.0f",item.getDv8()));
				}
				if (item.getNalsu() !=null) {
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}
				if (item.getLimitSuryang() !=null) {
					info.setLimitSuryang(String.format("%.0f",item.getLimitSuryang()));
				}
				if (item.getBomSourceKey() !=null) {
					info.setBomSourceKey(String.format("%.0f",item.getBomSourceKey()));
				}
				if (item.getOrgKey() !=null) {
					info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				}
				if (item.getParentKey() !=null) {
					info.setParentKey(String.format("%.0f",item.getParentKey()));
				}
				if (item.getFkocs0300Seq() !=null) {
					info.setFkocs0300Seq(String.format("%.0f",item.getFkocs0300Seq()));
				}
				String buyoCheck = "N";
				buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
				if(!buyoCheck.equalsIgnoreCase("Y")){
					buyoCheck = "N";
				}else if(buyoCheck.equalsIgnoreCase("Y") && !item.getBulyongCheck().equalsIgnoreCase(item.getHangmogCode())){
					buyoCheck = "Z";
				}else{
					buyoCheck = "Y";
				}
				info.setBulyongCheck(buyoCheck);
				response.addGrdOcs0303Item(info);
			}
		}
		
		//repeat combolist0307
		List<OCS0307U00GrdListItemInfo> listCombo0307Info = ocs0303Repository.getComboList0307Info(getHospitalCode(vertx, sessionId), request.getMemb(), request.getFkocs0300Seq(), request.getYaksokCode());
		if (!CollectionUtils.isEmpty(listCombo0307Info)) {
			for (OCS0307U00GrdListItemInfo item : listCombo0307Info) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getSangCode());
				info.setCodeName(item.getSangName());
//				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboList0307Item(info);
			}
		}
		
		return response.build();
	}
	
	private String fnOcsBulyongCheckOut(OCS0301Q09GrdOCS0303Info item,
			String buyoCheck) throws ParseException {
		Date date = DateUtil.toDate(item.getBulyongYmd(), DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(item.getBulyongYmd()) ||( date.equals(new Date()) || date.after(new Date()))){
			buyoCheck = "N";
		}else{
			buyoCheck = "Y";
		}
		return buyoCheck;
	}
}