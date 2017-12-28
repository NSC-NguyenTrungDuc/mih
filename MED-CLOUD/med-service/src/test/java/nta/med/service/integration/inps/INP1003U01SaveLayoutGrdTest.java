package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.core.glossary.DataRowState;
import nta.med.service.ihis.proto.InpsModelProto.INP1003U01grdINP1003Info;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1003U01SaveLayoutGrdTest extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		INP1003U01grdINP1003Info.Builder item = INP1003U01grdINP1003Info.newBuilder();
		item.setBunho("000040732");
		item.setReserDate("2016/12/12");
		item.setGwa("04");
		item.setDoctor("0410323");
		item.setPkinp1003("11");
		item.setDataRowState(DataRowState.MODIFIED.toString());
		
		InpsServiceProto.INP1003U01SaveLayoutGrdRequest request = InpsServiceProto.INP1003U01SaveLayoutGrdRequest.newBuilder()
				.setUserid("TEST")
				.setFkout1001("1001")
				.addGrdSave(item)
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
