package nta.med.service.integration.ocso;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdJaeryoProcessInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdJaeryoProcessWithUpdGubunInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdateGrdOrderInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OUT2016U00PatientLinkingContentInfo;
import nta.med.service.integration.MessageRequestTest;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class OCSACTUpdateTest extends MessageRequestTest {
	@Test
	public void testOCSACTUpdate() throws InterruptedException {

		List<OCSACTUpdateGrdOrderInfo> listInfo1 = new ArrayList<OCSACTUpdateGrdOrderInfo>();
		OCSACTUpdateGrdOrderInfo.Builder item = OCSACTUpdateGrdOrderInfo.newBuilder();
		item.setPkocs("7389");
		item.setJubsuDate("2016/02/22");
		item.setJubsuTime("1822");
		item.setActDoctor("10346");
		item.setInputControl("6");
		item.setSuryang("1");
		item.setNalsu("1");
		item.setFkout1001("4486");
		item.setJundalPart("OP");
		item.setGrdOrderInOutGubun("O");
		item.setGrdOrderActingDate("2016/02/22");
		item.setGrdOrderActingTime("1822");
		item.setGrdOrderActYn("Y");
		listInfo1.add(item.build());

		List<OCSACTUpdJaeryoProcessInfo> listInfo2 = new ArrayList<OCSACTUpdJaeryoProcessInfo>();
		OCSACTUpdJaeryoProcessInfo.Builder item2 = OCSACTUpdJaeryoProcessInfo.newBuilder();
		item2.setSuryang("1");
		item2.setDtRowFirstVal("620003228");
		item2.setIudGubun("N/A");
		item2.setInputId("10346");
		item2.setBomSourceKey("7389");
		item2.setHangmogCode("620003228");
		item2.setOrderGubun("N/A");
		item2.setNalsu("1");
		item2.setDivide("1");
		item2.setDvTime("*");
		item2.setSysId("10346");
		item2.setRowState("Added");
		listInfo2.add(item2.build());

		OcsoServiceProto.OCSACTUpdateRequest request = OcsoServiceProto.OCSACTUpdateRequest.newBuilder()
				.setRbtNonAct(true).setRbtAct(false).setIsUpdJaeryoProcess(true).setActYn("Y").setInOutGubun("O")
				.setPkocs("7389").setActingDate("2016/02/22").setActingTime("1822").setNewOcsKey("7389")
				.setJundalPart("OP").setOrderDate("2016/02/22").setUserId("10346").setBunho("000000139")
				.addAllJaeryoItem(listInfo2).addAllUpdateGrdOrderItem(listInfo1).build();
		sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
